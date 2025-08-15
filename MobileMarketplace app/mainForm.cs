using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMarketplace_app
{
    public partial class mainForm : Form
    {
        private readonly homeControl home = new homeControl();
        private readonly shopControl shop = new shopControl();
        private readonly SellControl sell = new SellControl();



        public mainForm()
        {
            InitializeComponent();
            home = new homeControl();
            shop = new shopControl();
            sell = new SellControl();


            mainPanel.Controls.Add(home);
            mainPanel.Controls.Add(shop);
            mainPanel.Controls.Add(sell);


            home.Dock = DockStyle.Fill;
            shop.Dock = DockStyle.Fill;
            sell.Dock = DockStyle.Fill;

            home.BringToFront(); // Show home control first
        }
        private void ShowScreen(UserControl screen)
        {
            // A) hide every child + kill their dim overlays if they have any
            foreach (Control c in mainPanel.Controls)
            {
                if (c is SellControl sc) sc.DeactivateDim();   // only SellControl has dimmers
                c.Visible = false;
            }

            // B) show & front-load the requested screen
            screen.Visible = true;
            screen.BringToFront();

            // C) if that screen *is* SellControl, light up its dimmers
            if (screen is SellControl sc2) sc2.ActivateDim();
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(home);
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(shop);
        }

        private void sellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(sell);
        }
        public void ShowLoginControl()
        {
           
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var acct = new AccountControl();
            acct.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(acct);

            // 2) load the current user’s data
            acct.LoadUser();

            // 3) show it
            ShowScreen(acct);
        }
    }
}

