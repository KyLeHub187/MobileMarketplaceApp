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
        homeControl home;
        shopControl shopAllDevices;
        SellControl Sell;


        public mainForm()
        {
            InitializeComponent();
            home = new homeControl();
            shopAllDevices = new shopControl();
            Sell = new SellControl();


            mainPanel.Controls.Add(home);
            mainPanel.Controls.Add(shopAllDevices);
            mainPanel.Controls.Add(Sell);


            home.Dock = DockStyle.Fill;
            shopAllDevices.Dock = DockStyle.Fill;
            Sell.Dock = DockStyle.Fill;

            home.BringToFront(); // Show home control first
        }
       
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            home.BringToFront();
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shopAllDevices.BringToFront();
        }

        private void sellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sell.BringToFront();
        }
    }
}
