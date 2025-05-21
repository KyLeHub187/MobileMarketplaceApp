using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMarketplace_app
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var host = new Form
            {
                Text = "Sell Screen",
                Width = 1258,
                Height = 793
            };

            // 2) instantiate and dock your UserControl
            var sell = new SellControl
            {
                Dock = DockStyle.Fill
            };
            host.Controls.Add(sell);

            // 3) run the host Form
            Application.Run(host);
        }
    }
}
