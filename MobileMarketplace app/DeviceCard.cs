using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MobileMarketplace_app.Models;   // make sure you have this

namespace MobileMarketplace_app
{
    public partial class deviceCard : UserControl
    {
        public deviceCard()
        {
            InitializeComponent();
        }

        // ← here's your new constructor for Option B
        public deviceCard(Device d) : this()
        {
            // bind the Device fields into your labels/picture
            Brand = d.Brand;
            Model = d.Model;
            Price = d.Price.ToString("C");
            Condition = d.Condition;
            DateAdded = d.CreatedDate.ToShortDateString();

            this.Margin = new Padding(10);

            // load the image if it exists
            if (!string.IsNullOrEmpty(d.FirstImagePath) && File.Exists(d.FirstImagePath))
                DeviceImage = Image.FromFile(d.FirstImagePath);
            else
                DeviceImage = null;
        }

        public Image DeviceImage
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }

        public string Brand
        {
            get => lblBrand.Text;
            set => lblBrand.Text = value;
        }

        public string Model
        {
            get => lblModel.Text;
            set => lblModel.Text = value;
        }

        public string Price
        {
            get => lblPrice.Text;
            set => lblPrice.Text = value;
        }

        public string Condition
        {
            get => lblCondition.Text;
            set => lblCondition.Text = value;
        }

        public string DateAdded
        {
            get => lblDateAdded.Text;
            set => lblDateAdded.Text = value;
        }

        // you can leave SetData(DataRow) in place if you ever want DataRow-based binding
        public void SetData(DataRow row)
        {
            Brand = row["Brand"].ToString();
            Model = row["Model"].ToString();
            Price = $"${row["Price"]}";
            Condition = row["Condition"].ToString();
            DateAdded = Convert.ToDateTime(row["CreatedDate"])
                               .ToShortDateString();

            var path = row["ImagePath"].ToString();
            DeviceImage = (!string.IsNullOrEmpty(path) && File.Exists(path))
                          ? Image.FromFile(path)
                          : null;
        }
    }
}
