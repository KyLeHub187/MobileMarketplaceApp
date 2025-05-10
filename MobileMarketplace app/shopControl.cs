using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MobileMarketplace_app.Models;

namespace MobileMarketplace_app
{
    public partial class shopControl : UserControl
    {
        // --- 1) P/Invoke for cue-banner (placeholder) text on ComboBoxes ---
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            [MarshalAs(UnmanagedType.LPWStr)] string lParam
        );
        private const int CB_SETCUEBANNER = 0x1703;

        // --- 2) In-memory cache of all devices ---
        private List<Device> _allDevices;
        private List<Device> _filteredDevices;
        private int _currentPage = 0;
        private const int PageSize = 15;
        public shopControl()
        {
            InitializeComponent();

            // Hook up Load event so we start pulling data as soon as the control is shown
            this.Load += shopControl_Load;
            btnSearch.Click += (s, e) => ApplyFilters();
            // NEW: fire ApplyFilters() when the user presses Enter in txtSearch
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ApplyFilters();
                    // Optionally suppress the "ding" sound
                    e.SuppressKeyPress = true;
                }
            };

            // Make the filter ComboBoxes more readable and give them placeholders
            var bigFont = new Font("Segoe UI", 12F, FontStyle.Regular);
            cmbType.Font = bigFont;
            cmbOS.Font = bigFont;
            cmbCondition.Font = bigFont;

            SendMessage(cmbType.Handle, CB_SETCUEBANNER, IntPtr.Zero, "Select device type");
            SendMessage(cmbOS.Handle, CB_SETCUEBANNER, IntPtr.Zero, "Select operating system");
            SendMessage(cmbCondition.Handle, CB_SETCUEBANNER, IntPtr.Zero, "Select condition");
        }

        // --- 3) First‐time setup: load from DB, display, and wire filters ---
        private void shopControl_Load(object sender, EventArgs e)
        {
            _allDevices = LoadDevicesFromDb();   // pull every row into a List<Device>
            _filteredDevices = _allDevices.ToList();
            HookupFilters();   // wires up ApplyFilters
            HookupPaging();    // wires up btnPrev/btnNext
            DisplayPage(0);                   // live‐update when filter changes
        }

        // --- 4) Data‐access: map each SqlDataReader row into a Device object ---
        private List<Device> LoadDevicesFromDb()
        {
            var list = new List<Device>();

            // DB.Cmd(sql) gives you a SqlCommand with the right connection string
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
            using (var cmd = DB.Cmd(
      "SELECT DeviceId, ImagePath FROM DeviceImages ORDER BY SortOrder"))
            {
                cmd.Connection.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int id = (int)rdr["DeviceId"];
                        string img = rdr["ImagePath"] as string;
                        var dev = list.FirstOrDefault(d => d.DeviceId == id);
                        if (dev != null && !string.IsNullOrEmpty(img))
                            dev.ImagePaths.Add(img);
                    }
                }
            }

            return list;
        }

        // --- 5) Render any collection of Device into your FlowLayoutPanel ---
        private void DisplayPage(int pageIndex)
        {
            int maxPage = (_filteredDevices.Count - 1) / PageSize;
            pageIndex = Math.Max(0, Math.Min(maxPage, pageIndex));
            _currentPage = pageIndex;

            var pageItems = _filteredDevices
                .Skip(pageIndex * PageSize)
                .Take(PageSize);

            flpDevices.Controls.Clear();
            foreach (var d in pageItems)
                flpDevices.Controls.Add(new deviceCard(d));

            btnPrev.Enabled = pageIndex > 0;
            btnNext.Enabled = pageIndex < maxPage;

            lblPage.Text = $"{pageIndex + 1} / {maxPage + 1}";
        }

        private void HookupPaging()
        {
            btnPrev.Click += (s, e) => DisplayPage(_currentPage - 1);
            btnNext.Click += (s, e) => DisplayPage(_currentPage + 1);
        }


        // --- 6) Wire every filter control to re-run ApplyFilters immediately ---
        private void HookupFilters()
        {
            cmbType.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbOS.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbCondition.SelectedIndexChanged += (s, e) => ApplyFilters();

            cbUnder100.CheckedChanged += (s, e) => ApplyFilters();
            cb100to250.CheckedChanged += (s, e) => ApplyFilters();
            cb250to500.CheckedChanged += (s, e) => ApplyFilters();
            cbOver500.CheckedChanged += (s, e) => ApplyFilters();

            cb16gb.CheckedChanged += (s, e) => ApplyFilters();
            cb32gb.CheckedChanged += (s, e) => ApplyFilters();
            cb64gb.CheckedChanged += (s, e) => ApplyFilters();
            cb128gb.CheckedChanged += (s, e) => ApplyFilters();
            cb256gb.CheckedChanged += (s, e) => ApplyFilters();
            cb512gb.CheckedChanged += (s, e) => ApplyFilters();
            cb1tb.CheckedChanged += (s, e) => ApplyFilters();
            cb2tb.CheckedChanged += (s, e) => ApplyFilters();
        }

        // --- 7) In-memory LINQ filter + immediate redisplay ---
        private void ApplyFilters()
        {
            var term = (txtSearch.Text ?? "").Trim();

            _filteredDevices = _allDevices
              .Where(d =>
                 // === your search logic ===
                 string.IsNullOrEmpty(term)
                 || new[] { d.Brand, d.Model, d.OS, d.DeviceType }
                      .Any(field =>
                          !string.IsNullOrEmpty(field)
                          && field.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0
                      )
                 // === existing combo- and checkbox filters ===
                 && (cmbType.SelectedIndex <= 0 || d.DeviceType == cmbType.Text)
                 && (cmbOS.SelectedIndex <= 0 || d.OS == cmbOS.Text)
                 && (cmbCondition.SelectedIndex <= 0 || d.Condition == cmbCondition.Text)
                 && (
                      (!cbUnder100.Checked && !cb100to250.Checked && !cb250to500.Checked && !cbOver500.Checked)
                   || (cbUnder100.Checked && d.Price < 100M)
                   || (cb100to250.Checked && d.Price >= 100M && d.Price <= 250M)
                   || (cb250to500.Checked && d.Price > 250M && d.Price <= 500M)
                   || (cbOver500.Checked && d.Price > 500M)
                 )
                 && (
                      (!cb16gb.Checked && !cb32gb.Checked && !cb64gb.Checked &&
                       !cb128gb.Checked && !cb256gb.Checked && !cb512gb.Checked &&
                       !cb1tb.Checked && !cb2tb.Checked)
                   || (cb16gb.Checked && d.Storage == "16GB")
                   || (cb32gb.Checked && d.Storage == "32GB")
                   || (cb64gb.Checked && d.Storage == "64GB")
                   || (cb128gb.Checked && d.Storage == "128GB")
                   || (cb256gb.Checked && d.Storage == "256GB")
                   || (cb512gb.Checked && d.Storage == "512GB")
                   || (cb1tb.Checked && d.Storage == "1TB")
                   || (cb2tb.Checked && d.Storage == "2TB")
                 )
              )
              .ToList();

            DisplayPage(0);
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = -1;  // no selection
            cmbOS.SelectedIndex = -1;
            cmbCondition.SelectedIndex = -1;

            // --- B) Uncheck all Price checkboxes ---
            cbUnder100.Checked = false;
            cb100to250.Checked = false;
            cb250to500.Checked = false;
            cbOver500.Checked = false;

            // --- C) Uncheck all Storage checkboxes ---
            cb16gb.Checked = false;
            cb32gb.Checked = false;
            cb64gb.Checked = false;
            cb128gb.Checked = false;
            cb256gb.Checked = false;
            cb512gb.Checked = false;
            cb1tb.Checked = false;
            cb2tb.Checked = false;

            // --- D) Reset filtered list & redisplay page 0 ---
            _filteredDevices = _allDevices.ToList();
            DisplayPage(0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
