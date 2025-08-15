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
        private Panel pnlRecent;
        private Label lblRecent;
        private ListBox lstRecentActivity;


        public homeControl()
        {
            InitializeComponent();

            // modern Recent Activity card
            pnlRecent = new Panel
            {
                Name = "pnlRecent",
                BackColor = Color.White,
                Location = new Point(40, 160),
                Size = new Size(310, 260),
                Padding = new Padding(16),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            pnlRecent.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var shadow = new Rectangle(4, 6, pnlRecent.Width - 8, pnlRecent.Height - 8);
                using (var sb = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
                    g.FillRectangle(sb, shadow);

                var r = new Rectangle(0, 0, pnlRecent.Width - 8, pnlRecent.Height - 8);
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 12;
                    path.AddArc(r.X, r.Y, radius, radius, 180, 90);
                    path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
                    path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();
                    using (var bg = new SolidBrush(Color.White)) g.FillPath(bg, path);
                    using (var pen = new Pen(Color.FromArgb(230, 230, 230))) g.DrawPath(pen, path);
                }
            };

            lblRecent = new Label
            {
                Text = "Recent Activity",
                Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(8, 6)
            };

            lstRecentActivity = new ListBox
            {
                BorderStyle = BorderStyle.None,
                DrawMode = DrawMode.OwnerDrawFixed,
                ItemHeight = 36,
                IntegralHeight = false,
                Font = new Font("Segoe UI", 9f),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Location = new Point(8, 36),
                Size = new Size(pnlRecent.Width - 28, pnlRecent.Height - 52),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            lstRecentActivity.DrawItem += (s, e) =>
            {
                e.DrawBackground();
                if (e.Index < 0) return;

                var g = e.Graphics;
                var text = lstRecentActivity.Items[e.Index].ToString();
                var parts = text.Split(new[] { " — " }, 2, StringSplitOptions.None);
                var date = parts.Length > 0 ? parts[0] : "";
                var title = parts.Length > 1 ? parts[1] : text;

                var bg = (e.State & DrawItemState.Selected) != 0 ? Color.FromArgb(245, 248, 250) : Color.White;
                using (var b = new SolidBrush(bg)) g.FillRectangle(b, e.Bounds);

                using (var accent = new SolidBrush(Color.FromArgb(0, 180, 220)))
                    g.FillRectangle(accent, new Rectangle(e.Bounds.X, e.Bounds.Y + 6, 3, e.Bounds.Height - 12));

                var titleFont = new Font("Segoe UI Semibold", 9f);
                var dateFont = new Font("Segoe UI", 8f, FontStyle.Italic);
                var textX = e.Bounds.X + 10;
                var textY = e.Bounds.Y + 6;

                using (var tBrush = new SolidBrush(Color.Black))
                    g.DrawString(title, titleFont, tBrush, textX, textY);

                using (var dBrush = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
                    g.DrawString(date, dateFont, dBrush, textX, textY + 18);
            };

            pnlRecent.Controls.Add(lblRecent);
            pnlRecent.Controls.Add(lstRecentActivity);
            this.Controls.Add(pnlRecent);

            // your existing homeControl setup...
            this.Load += homeControl_Load;
            scrollTimer.Interval = 30;
            scrollTimer.Tick += ScrollTimer_Tick;
        }


        private void LoadRecentActivity()
        {
            lstRecentActivity.Items.Clear();

            using (var cmd = DB.Cmd(@"
        SELECT TOP 8 Brand, Model, CreatedDate
        FROM Devices
        ORDER BY CreatedDate DESC"))
            {
                cmd.Connection.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var brand = rdr["Brand"]?.ToString();
                        var model = rdr["Model"]?.ToString();
                        var date = ((DateTime)rdr["CreatedDate"]).ToShortDateString();
                        lstRecentActivity.Items.Add($"{date} — {brand} {model} listed");
                    }
                }
            }
        }

        private void homeControl_Load(object sender, EventArgs e)
        {
            // 1) Load every Device (with ImagePaths) into memory
            _allDevices = LoadDevicesFromDb();

            // 2) Show welcome
            lblWelcome.Text = $"Welcome, {UserSession.FirstName}";
            LoadDeviceCards();
            LoadRecentActivity();
            // 3) Build the carousel
            
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
