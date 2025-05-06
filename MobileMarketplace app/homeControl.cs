using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MobileMarketplace_app
{
    public partial class homeControl : UserControl
    {
        private Timer scrollTimer = new Timer();
        private List<deviceCard> deviceCards = new List<deviceCard>();
        private int scrollSpeed = 2; // pixels per tick
        private int cardWidth = 160; // match deviceCard width
        private int cardSpacing = 10;
        private int currentOffset = 0;

        public homeControl()
        {
            InitializeComponent();
            this.Load += homeControl_Load;

            scrollTimer.Interval = 30; // milliseconds
            scrollTimer.Tick += ScrollTimer_Tick;
        }

        private void homeControl_Load(object sender, EventArgs e)
        {
            LoadDeviceCards();
            lblWelcome.Text = $"Welcome, {UserSession.FirstName}";

        }

        private void LoadDeviceCards()
        {
            DataTable devices = new DataTable();

            using (SqlConnection conn = DB.Conn)
            {
                conn.Open();
                string query = "SELECT TOP 20 * FROM devices ORDER BY CreatedDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(devices);
            }

            pnlContainer.Controls.Clear();
            deviceCards.Clear();

            int x = 0;
            foreach (DataRow row in devices.Rows)
            {
                deviceCard card = new deviceCard();
                card.Width = cardWidth;
                card.SetData(row);
                card.Location = new Point(x, 0);

                deviceCards.Add(card);
                pnlContainer.Controls.Add(card);

                x += cardWidth + cardSpacing;
            }

            pnlContainer.Width = x;
            pnlContainer.Height = carouselPanel.Height;
            pnlContainer.Location = new Point(0, 0);
            scrollTimer.Start();
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            pnlContainer.Left -= scrollSpeed;

            if (deviceCards.Count == 0)
                return;

            var firstCard = deviceCards[0];

            // Has the first card completely moved out of view?
            if (firstCard.Right + pnlContainer.Left <= 0)
            {
                deviceCards.RemoveAt(0);
                deviceCards.Add(firstCard);

                // Move to the end of the last card
                var lastCard = deviceCards[deviceCards.Count - 2];
                firstCard.Left = lastCard.Right + cardSpacing;

                // Refresh container
                pnlContainer.Controls.Clear();
                pnlContainer.Controls.AddRange(deviceCards.ToArray());
            }

        }
    }
}
