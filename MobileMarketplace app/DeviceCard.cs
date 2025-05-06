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
    public partial class deviceCard : UserControl
    {
        public deviceCard()
        {
            InitializeComponent();
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
        public void SetData(DataRow row)
        {
            Brand = row["Brand"].ToString();
            Model = row["Model"].ToString();
            Price = $"${row["Price"]}";
            Condition = row["Condition"].ToString();
            DateAdded = Convert.ToDateTime(row["CreatedDate"]).ToShortDateString();

            string imagePath = row["ImagePath"].ToString();
            if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
            {
                DeviceImage = Image.FromFile(imagePath);
            }
            else
            {
                DeviceImage = null;
            }
        }
    }

}
