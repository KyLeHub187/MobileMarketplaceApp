using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MobileMarketplace_app
{
    public partial class SellControl : UserControl
    {
        private readonly List<string> _imagePaths = new List<string>();
        private readonly string[] AndroidVersions = { "Android 10", "Android 11", "Android 12", "Android 13", "Other", "Unknown" };
        private readonly string[] iOSVersions = { "iOS 14", "iOS 15", "iOS 16", "iOS 17", "Other", "Unknown" };
        private readonly ToolTip tip = new ToolTip();
        private readonly Dictionary<Panel, Form> _dimOverlays = new Dictionary<Panel, Form>();
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
                    ["Android"] = new List<string> { "Samsung", "Huawei" },
                    ["IOS"] = new List<string> { "Apple (iPad)" }
                }
            };

        private string _deviceType;
        private string _os;
        private string _osVersion;
        public void ActivateDim()     // called right after BringToFront()
        {
            ShowDimOverlay(pnlSell);
            ShowDimOverlay(pnlOS);
        }

        public void DeactivateDim()   // called before switching to another screen
        {
            CloseAllOverlays();
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            CloseAllOverlays();          // nuke the dim forms
        }

        // fires if the control is physically removed from its parent
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.Parent == null)     // got disposed / swapped out
                CloseAllOverlays();
        }
        private void CloseAllOverlays()
        {
            foreach (var ov in _dimOverlays.Values.ToList())
                ov.Close();
            _dimOverlays.Clear();
        }

        // ── fires every time the control becomes hidden or visible ──
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!this.Visible) CloseAllOverlays();   // hiding → nuke forms
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private PictureBox[] _boxes;

        public SellControl()
        {
            InitializeComponent();

            _boxes = new[]
            {
                pbDeviceImage1, pbDeviceImage2, pbDeviceImage3, pbDeviceImage4, pbDeviceImage5
            };

            cmbColor.Items.AddRange(new[]
            {
                "Black","White","Silver","Space Gray","Gold","Rose Gold","Midnight","Starlight",
                "Red","Blue","Green","Purple","Yellow","Coral","Graphite","Cobalt","Champagne"
            });

            cmbStorage.Items.AddRange(new[]
            {
                "8 GB","16 GB","32 GB","64 GB","128 GB","256 GB","512 GB","1 TB"
            });

            cmbCondition.Items.AddRange(new[]
            {
                "New","Refurbished","Open Box","Used – Excellent","Used – Good",
                "Used – Fair","For Parts / Not Working"
            });
            AutoSizeDropDown(cmbCondition);

            RefreshSlots();

            btnListDevice.BackColor = ColorTranslator.FromHtml("#4cd137");
            btnListDevice.ForeColor = Color.White;
            btnAndroid.BackColor = ColorTranslator.FromHtml("#4cd137");
            btnAndroid.ForeColor = Color.White;
            btnIOS.BackColor = ColorTranslator.FromHtml("#4cd137");
            btnIOS.ForeColor = Color.White;
            btnNext.BackColor = ColorTranslator.FromHtml("#4cd137");
            btnNext.ForeColor = Color.White;

            cmbBrand.SelectedIndexChanged += (s, e) => txtBrand.Visible = cmbBrand.SelectedItem?.ToString() == "Not in list";

            pnlSell.Resize += (s, e) => RepositionOverlay(pnlSell);
            pnlSell.Move += (s, e) => RepositionOverlay(pnlSell);
            pnlOS.Resize += (s, e) => RepositionOverlay(pnlOS);
            pnlOS.Move += (s, e) => RepositionOverlay(pnlOS);
            pnlDeviceType.Resize += (s, e) => RepositionOverlay(pnlDeviceType);
            pnlDeviceType.Move += (s, e) => RepositionOverlay(pnlDeviceType);

            this.Load += (s, e) =>
            {
                var host = FindForm();
                host.Move += (s2, e2) => RepositionAllOverlays();
                host.Resize += (s2, e2) => RepositionAllOverlays();
               
            };

            btnNext.Click += (s, e) =>
            {
                HideDimOverlay(pnlSell);
                ShowDimOverlay(pnlOS);
                PopulateBrands();
            };
            btnPhone.Click += (s, e) =>
            {
                _deviceType = "Phone";
                HideDimOverlay(pnlOS);
                ShowDimOverlay(pnlDeviceType);
                pnlDeviceType.Visible = false;
                pbCheckMark.Visible = true;
            };
            btnTablet.Click += (s, e) =>
            {
                _deviceType = "Tablet";
                HideDimOverlay(pnlOS);
                ShowDimOverlay(pnlDeviceType);
                pnlDeviceType.Visible = false;
                pbCheckMark.Visible = true;
            };
            btnChangeDeviceType.Click += (s, e) =>
            {
                pbCheckMark.Visible = false;
                HideDimOverlay(pnlDeviceType);
                ShowDimOverlay(pnlOS);
                pnlDeviceType.Visible = true;
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
                    cmbBrand.Items.AddRange(osBrands[_os].ToArray());

                cmbBrand.Items.Add("Not in list");
            }

            AutoSizeDropDown(cmbBrand);
        }

        private void AutoSizeDropDown(ComboBox cmb)
        {
            int maxW = 0;
            using (var g = cmb.CreateGraphics())
            {
                foreach (var itm in cmb.Items)
                {
                    int w = (int)g.MeasureString(itm.ToString(), cmb.Font).Width;
                    if (w > maxW) maxW = w;
                }
            }
            cmb.DropDownWidth = maxW + 20;
        }

        private void ShowDimOverlay(Panel target)
        {
            if (_dimOverlays.ContainsKey(target)) return;

            var ov = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.Manual,
                BackColor = Color.Black,
                Opacity = 0.1,
                Owner = FindForm()
            };
            ov.Size = target.Size;
            ov.Location = target.PointToScreen(Point.Empty);
            ov.Show();
            _dimOverlays[target] = ov;
        }

        private void HideDimOverlay(Panel target)
        {
            if (_dimOverlays.TryGetValue(target, out var ov))
            {
                ov.Close();
                _dimOverlays.Remove(target);
            }
        }

        private void RepositionOverlay(Panel target)
        {
            if (_dimOverlays.TryGetValue(target, out var ov))
            {
                ov.Size = target.Size;
                ov.Location = target.PointToScreen(Point.Empty);
            }
        }

        private void RepositionAllOverlays()
        {
            foreach (var kv in _dimOverlays)
                RepositionOverlay(kv.Key);
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

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            int idx = (int)((Button)sender).Tag;
            _imagePaths.RemoveAt(idx);
            RefreshSlots();
        }

        private void RefreshSlots()
        {
            for (int i = 0; i < _boxes.Length; i++)
            {
                var box = _boxes[i];
                box.Controls.Clear();

                if (i < _imagePaths.Count)
                {
                    try
                    {
                        using (var fs = new FileStream(_imagePaths[i], FileMode.Open, FileAccess.Read))
                        using (var img = Image.FromStream(fs))
                        {
                            box.Image = new Bitmap(img);
                            box.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load “{_imagePaths[i]}”:\n{ex.Message}");
                        box.Image = null;
                        continue;
                    }

                    var btn = new Button
                    {
                        Text = "×",
                        Font = new Font("Segoe UI", 8, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = Color.Red,
                        FlatStyle = FlatStyle.Flat,
                        Size = new Size(20, 20),
                        Anchor = AnchorStyles.Top | AnchorStyles.Right,
                        Location = new Point(box.Width - 18, 2),
                        Tag = i
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Click += CloseBtn_Click;
                    box.Controls.Add(btn);
                    btn.BringToFront();
                }
                else
                {
                    box.Image = null;
                }
            }
        }

        private void cmbOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOS.SelectedIndex <= 0) return;
            pnlOS.Visible = false;
            pbCheckMark2.Visible = true;
            HideDimOverlay(pnlSell);
            ShowDimOverlay(pnlOS);
            _osVersion = cmbOS.SelectedItem.ToString();
            PopulateBrands();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideDimOverlay(pnlOS);
            ShowDimOverlay(pnlSell);
            pnlOS.Visible = true;
            pbCheckMark2.Visible = false;
            cmbBrand.Items.Clear();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                if (_imagePaths.Count < _boxes.Length)
                {
                    _imagePaths.Add(dlg.FileName);
                    RefreshSlots();
                }
            }
        }
    }
}
