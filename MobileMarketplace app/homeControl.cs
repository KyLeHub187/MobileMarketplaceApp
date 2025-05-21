using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MobileMarketplace_app.Models;

namespace MobileMarketplace_app
{
    public partial class homeControl : UserControl
    {
        private Timer scrollTimer = new Timer();
        private List<deviceCard> deviceCards = new List<deviceCard>();
        private List<Device> _allDevices;
        private int scrollSpeed = 2;    // pixels per tick
        private int cardWidth = 160;  // should match your deviceCard.Width
        private int cardSpacing = 10;

        public homeControl()
        {
            InitializeComponent();
            this.Load += homeControl_Load;

            scrollTimer.Interval = 30;
            scrollTimer.Tick += ScrollTimer_Tick;
        }

        private void homeControl_Load(object sender, EventArgs e)
        {
            // 1) Load every Device (with ImagePaths) into memory
            _allDevices = LoadDevicesFromDb();

            // 2) Show welcome
            lblWelcome.Text = $"Welcome, {UserSession.FirstName}";

            // 3) Build the carousel
            LoadDeviceCards();
        }

        /// <summary>
        /// Duplicates your shopControl.LoadDevicesFromDb logic
        /// so each Device has its ImagePaths populated.
        /// </summary>
        private List<Device> LoadDevicesFromDb()
        {
            var list = new List<Device>();

            // --- 1) Pull the Devices table ---
            using (var cmd = DB.Cmd("SELECT * FROM Devices"))
            {
                cmd.Connection.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Device
                        {
                            DeviceId = (int)rdr["DeviceId"],
                            DeviceType = rdr["DeviceType"] as string,
                            Brand = rdr["Brand"] as string,
                            Model = rdr["Model"] as string,
                            Price = (decimal)rdr["Price"],
                            Condition = rdr["Condition"] as string,
                            OS = rdr["OS"] as string,
                            Storage = rdr["Storage"] as string,
                            Color = rdr["Color"] as string,
                            Description = rdr["Description"] as string,
                            SellerId = (int)rdr["SellerId"],
                            BuyerId = rdr.IsDBNull(rdr.GetOrdinal("BuyerId"))
                                            ? (int?)null
                                            : (int)rdr["BuyerId"],
                            IsActive = (bool)rdr["IsActive"],
                            CreatedDate = (DateTime)rdr["CreatedDate"],
                            ModifiedDate = rdr.IsDBNull(rdr.GetOrdinal("ModifiedDate"))
                                            ? (DateTime?)null
                                            : (DateTime)rdr["ModifiedDate"]
                        });
                    }
                }
            }

            // --- 2) Pull the first image per device ---
            const string imgSql = @"
                SELECT DeviceId, ImagePath 
                FROM DeviceImages 
                WHERE SortOrder = 1
                ORDER BY DeviceId";
            using (var cmd = DB.Cmd(imgSql))
            {
                cmd.Connection.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var id = (int)rdr["DeviceId"];
                        var img = rdr["ImagePath"] as string;
                        var dev = list.FirstOrDefault(d => d.DeviceId == id);
                        if (dev != null && !string.IsNullOrWhiteSpace(img))
                            dev.ImagePaths.Add(img);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Takes the 20 most-recent Devices and spins them into
        /// a continuously-scrolling carousel using your DeviceCard(Device) ctor.
        /// </summary>
        private void LoadDeviceCards()
        {
            // grab the newest 20
            var toShow = _allDevices
                .OrderByDescending(d => d.CreatedDate)
                .Take(20)
                .ToList();

            pnlContainer.Controls.Clear();
            deviceCards.Clear();

            int x = 0;
            foreach (var d in toShow)
            {
                // use your existing ctor that binds d.FirstImagePath!
                var card = new deviceCard(d);
                card.Width = cardWidth;
                card.Left = x;

                deviceCards.Add(card);
                pnlContainer.Controls.Add(card);

                x += cardWidth + cardSpacing;
            }

            // size & position container, then start scrolling
            pnlContainer.Width = x;
            pnlContainer.Height = carouselPanel.Height;
            pnlContainer.Left = 0;
            scrollTimer.Start();
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            pnlContainer.Left -= scrollSpeed;

            if (deviceCards.Count == 0) return;

            var first = deviceCards[0];

            // once the first card is fully out of view...
            if (first.Right + pnlContainer.Left <= 0)
            {
                deviceCards.RemoveAt(0);
                deviceCards.Add(first);

                // move it to follow the current last card
                var last = deviceCards[deviceCards.Count - 2];
                first.Left = last.Right + cardSpacing;

                // re-add in order
                pnlContainer.Controls.Clear();
                pnlContainer.Controls.AddRange(deviceCards.ToArray());
            }
        }
    }
}
