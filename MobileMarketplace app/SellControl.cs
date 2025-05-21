using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace MobileMarketplace_app
{
    
    public partial class SellControl : UserControl
    {
        private readonly string[] AndroidVersions = { "Android 10", "Android 11", "Android 12", "Android 13", "Other", "Unknown" };
        private readonly string[] iOSVersions = { "iOS 14", "iOS 15", "iOS 16", "iOS 17", "Other", "Unknown" };
        private readonly ToolTip tip = new ToolTip();
        private readonly Dictionary<Panel, Form> _dimOverlays
            = new Dictionary<Panel, Form>();
        // …your previous fields…

        // 1) brands by device & OS
        private readonly Dictionary<string, Dictionary<string, List<string>>> _brandsByDeviceAndOs
          = new Dictionary<string, Dictionary<string, List<string>>>()
          {
              ["Phone"] = new Dictionary<string, List<string>>()
              {
                  ["Android"] = new List<string>
               {
                  "Samsung", "Google (Pixel)", "OnePlus", "Xiaomi (Mi/Redmi/Poco)", "Oppo", "Vivo",
                  "Realme", "Motorola", "Sony", "Huawei", "Nokia (HMD Global)", "Asus", "Lenovo",
                  "ZTE", "TCL", "Alcatel", "HTC", "LG (pre-2021)", "Meizu", "Tecno", "Infinix",
                  "Lava", "Blackview", "Cubot", "Doogee", "Ulefone", "Umidigi"


                },
                  ["IOS"] = new List<string> { "Apple" }
              },
              ["Tablet"] = new Dictionary<string, List<string>>()
              {
                  ["Android"] = new List<string> { "Samsung", "Huawei", /*…*/ },
                  ["IOS"] = new List<string> { "Apple (iPad)" }
              }
          };  

        private string _deviceType;     
        private string _os;              
        private string _osVersion;


        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(
        IntPtr hWnd,
        int Msg,
        IntPtr wParam,
        string lParam
    );

        private const int EM_SETCUEBANNER = 0x1501;

        private List<string> _brandCache;
       


        public SellControl()
        {
            InitializeComponent();
            cmbBrand.SelectedIndexChanged += (s, e) =>
            {
                txtBrand.Visible = cmbBrand.SelectedItem?.ToString() == "Not in list";
            };
            cmbModel.SelectedIndexChanged += (s, e) =>
            {
                txtModel.Visible = cmbModel.SelectedItem?.ToString() == "Not in list";
            };

            pnlSell.Resize += (s, e) => RepositionOverlay(pnlSell);
            pnlSell.Move += (s, e) => RepositionOverlay(pnlSell);
            pnlOS.Resize += (s, e) => RepositionOverlay(pnlOS);
            pnlOS.Move += (s, e) => RepositionOverlay(pnlOS);
            pnlDeviceType.Resize += (s, e) => RepositionOverlay(pnlDeviceType);
            pnlDeviceType.Move += (s, e) => RepositionOverlay(pnlDeviceType);

            this.Load += (s, e) => {
                ShowDimOverlay(pnlSell);
                ShowDimOverlay(pnlOS);
            };
            btnNext.Click += (s, e) =>
            {
                HideDimOverlay(pnlSell);
                ShowDimOverlay(pnlOS);
                PopulateBrands();
            };
            btnPhone.Click += (s, e) => 
            {
                HideDimOverlay(pnlOS);
                ShowDimOverlay(pnlDeviceType);
                _deviceType = "Phone";
            };           
            btnTablet.Click += (s, e) => 
            {
                HideDimOverlay(pnlOS);
                ShowDimOverlay(pnlDeviceType);
                _deviceType = "Tablet";
            };
            btnChangeDeviceType.Click += (s, e) => 
            {
                HideDimOverlay(pnlDeviceType);
                ShowDimOverlay(pnlOS);
            };
            btnBack.Click += (s, e) =>
            {
                HideDimOverlay(pnlOS);
                ShowDimOverlay(pnlSell);
                cmbBrand.Items.Clear();
                cmbModel.Items.Clear();
            };
            btnAndroid.Click += (s, e) =>
            {
                _os = "Android";
                ShowOsPicker(AndroidVersions, "Android OS");
               
            };
            btnIOS.Click += (s, e) =>
            {
                _os = "IOS";
                ShowOsPicker(iOSVersions, "IOS OS");
            };




            tip.SetToolTip(pbInfo, "If exact color is not listed, select closest match");

            var iconBmp = SystemIcons.Question.ToBitmap();
            pbInfo.Image = new Bitmap(iconBmp, new Size(16, 16));

            btnNext.Visible = false;
            cmbOS.Visible = false;
            btnChangeOS.Visible = false;

            btnAndroid.Click += (s, e) => ShowOsPicker(AndroidVersions, "Android OS");
            btnIOS.Click += (s, e) => ShowOsPicker(iOSVersions, "iOS OS");
            btnChangeOS.Click += (s, e) => ResetOsPicker();



            SetPlaceholder(txtPrice, "0.00");
            SetPlaceholder(txtModel, "Model");
            SetPlaceholder(txtBrand, "Brand");
        }

        private void PopulateBrands()
        {
            cmbBrand.Items.Clear();

            if (!string.IsNullOrEmpty(_deviceType) && _brandsByDeviceAndOs.ContainsKey(_deviceType))
            {
                var osBrands = _brandsByDeviceAndOs[_deviceType];
                if (!string.IsNullOrEmpty(_os) && osBrands.ContainsKey(_os))
                {
                    cmbBrand.Items.AddRange(osBrands[_os].ToArray());
                }

                cmbBrand.Items.Add("Not in list");
            }
        }


     



        public void ShowDimOverlay(Panel target)
        {
            if (_dimOverlays.ContainsKey(target)) return;

            var overlay = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.Manual,
                BackColor = Color.Black,
                Opacity = 0.1,
                Owner = this.FindForm()
            };
            overlay.Size = target.Size;
            overlay.Location = target.PointToScreen(Point.Empty);
            overlay.Show();

            _dimOverlays[target] = overlay;
        }

        public void HideDimOverlay(Panel target)
        {
            if (!_dimOverlays.TryGetValue(target, out var ov)) return;
            ov.Close();
            _dimOverlays.Remove(target);
        }

        private void RepositionOverlay(Panel target)
        {
            if (!_dimOverlays.TryGetValue(target, out var ov)) return;
            ov.Size = target.Size;
            ov.Location = target.PointToScreen(Point.Empty);
        }

        private void SetPlaceholder(TextBox tb, string placeholder)
        {
            SendMessage(tb.Handle, EM_SETCUEBANNER, (IntPtr)1, placeholder);
        }

        private void ShowOsPicker(string[] versions, string placeholder)
        {
            cmbOS.Items.Clear();
            cmbOS.Items.Add(placeholder);
            cmbOS.Items.AddRange(versions);

            cmbOS.SelectedIndex = 0;

            btnNext.Visible = false;

            cmbOS.Visible = true;
            btnChangeOS.Visible = true;
            btnAndroid.Visible = false;
            btnIOS.Visible = false;
        }

        private void ResetOsPicker()
        {
            cmbOS.Visible = false;
            btnChangeOS.Visible = false;
            btnAndroid.Visible = true;
            btnIOS.Visible = true;
        }
        void SetDeviceTypeEnabled(bool on)
        {
         

            // disable/enable labels + swap their color so they visibly gray out
            lblPhone.Enabled = on;
            lblTablet.Enabled = on;
            lblPhone.ForeColor = on
                ? SystemColors.ControlText
                : SystemColors.GrayText;
            lblTablet.ForeColor = on
                ? SystemColors.ControlText
                : SystemColors.GrayText;
        }



        private void lblPhone_Click(object sender, EventArgs e)
        {
            pnlOS.Visible = true;
            SetDeviceTypeEnabled(false);
        }

        private void lblTablet_Click(object sender, EventArgs e)
        {
            pnlOS.Visible = true;
            SetDeviceTypeEnabled(false);
        }


        private void btnChangeOS_Click(object sender, EventArgs e)
        {
            btnAndroid.Visible = true;
            btnIOS.Visible = true;
            cmbOS.Visible = false;
            btnChangeOS.Visible = false;
            btnNext.Visible = false;
        }

        private void pbPhone_Click(object sender, EventArgs e)
        {
            pnlOS.Visible = true;
            SetDeviceTypeEnabled(false);
        }

        private void pbTablet_Click(object sender, EventArgs e)
        {
            pnlOS.Visible = true;
            SetDeviceTypeEnabled(false);
        }
       
        private void pnlSell_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {

        }



      


        private void cmbOS_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbOS.SelectedIndex <= 0) return;
            HideDimOverlay(pnlSell);
            ShowDimOverlay(pnlOS);
            _osVersion = cmbOS.SelectedItem.ToString();
            PopulateBrands();
        }
    }
}
        
    

