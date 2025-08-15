using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using MobileMarketplace_app.Models;

namespace MobileMarketplace_app
{
    public partial class deviceCard : UserControl
    {
        public deviceCard()
        {
            InitializeComponent();
        }

        // ← The “mega‐styled” constructor, now pointing at `this` instead of `panelCard`
        public deviceCard(Device d) : this()
        {
            // ————————————————————————————————
            // A) Bind the Device data into your labels/picture
            // ————————————————————————————————
            Brand = d.Brand;
            Model = d.Model;
            Price = d.Price.ToString("C");
            Condition = d.Condition;
            DateAdded = d.CreatedDate.ToShortDateString();
            this.Margin = new Padding(10);  // spacing in the grid

            // Load the first available image
            if (!string.IsNullOrEmpty(d.FirstImagePath) && File.Exists(d.FirstImagePath))
            {
                DeviceImage = Image.FromFile(d.FirstImagePath);
            }
            else
            {
                DeviceImage = null;
            }

            // ————————————————————————————————
            // B) Dark‐mode background + neon border + rounded corners
            // ————————————————————————————————

            // 1) Dark charcoal background for the entire deviceCard control
            this.BackColor = Color.FromArgb(35, 35, 35);

            // 2) Draw a 1px cyan‐neon border on the control’s Paint event
            this.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(0, 180, 220), 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var r = this.ClientRectangle;
                    e.Graphics.DrawRectangle(
                        pen,
                        new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1)
                    );
                }
            };

            // 3) Round the corners of the UserControl (12px radius)
            this.Load += (s, e) =>
            {
                int radius = 12;
                var gp = new GraphicsPath();
                var rect = new Rectangle(0, 0, this.Width, this.Height);
                gp.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                gp.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                gp.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                gp.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                gp.CloseFigure();
                this.Region = new Region(gp);
            };

            // 4) Hover effect: brighten the card when the mouse enters/leaves
            this.MouseEnter += (s, e) =>
            {
                this.BackColor = Color.FromArgb(45, 45, 45);
            };
            this.MouseLeave += (s, e) =>
            {
                this.BackColor = Color.FromArgb(35, 35, 35);
            };

            // ————————————————————————————————
            // C) Style the inner controls (text + image) to pop
            // ————————————————————————————————

            // PictureBox (assumed named pictureBox1): small neon‐border + floating background
            pictureBox1.BackColor = Color.FromArgb(50, 50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Paint += (s, e) =>
            {
                using (var p = new Pen(Color.FromArgb(0, 180, 220), 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rr = new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
                    e.Graphics.DrawRectangle(p, rr);
                }
            };

            // Brand (big, bold, neon‐cyan)
            lblBrand.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBrand.ForeColor = Color.FromArgb(0, 180, 220);
            lblBrand.TextAlign = ContentAlignment.MiddleCenter;

            // Model (clean white)
            lblModel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblModel.ForeColor = Color.White;
            lblModel.TextAlign = ContentAlignment.MiddleCenter;

            // Price (neon‐green accent)
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(0, 255, 100);
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;

            // Condition (italic, soft gray)
            lblCondition.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblCondition.ForeColor = Color.FromArgb(200, 200, 200);
            lblCondition.TextAlign = ContentAlignment.MiddleCenter;

            // DateAdded (small, muted gray)
            lblDateAdded.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            lblDateAdded.ForeColor = Color.FromArgb(150, 150, 150);
            lblDateAdded.TextAlign = ContentAlignment.MiddleCenter;
        }

        // ————————————————————————————————
        // Properties to bind into your Designer’s pictureBox & labels
        // ————————————————————————————————

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

        // If you still want to support DataRow binding:
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
