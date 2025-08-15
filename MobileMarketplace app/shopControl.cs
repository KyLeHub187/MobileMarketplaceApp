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

            // ———————————
            // 1) Load + Search Wiring
            // ———————————
            this.Load += shopControl_Load;


            btnSearch.Click += (s, e) =>
            {
                ApplyFilters();
            };

            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ApplyFilters();
                    e.SuppressKeyPress = true; // prevent ding sound
                }
            };


            // ———————————
            // 2) Dark/Neon Styling for ComboBoxes
            // ———————————

            // ComboBoxes only support FlatStyle, BackColor, ForeColor, DropDownStyle, etc.
            cmbType.FlatStyle = FlatStyle.Flat;
            cmbType.BackColor = Color.White;
            cmbType.ForeColor = Color.Black;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbOS.FlatStyle = FlatStyle.Flat;
            cmbOS.BackColor = Color.White;
            cmbOS.ForeColor = Color.Black;
            cmbOS.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbCondition.FlatStyle = FlatStyle.Flat;
            cmbCondition.BackColor = Color.White;
            cmbCondition.ForeColor = Color.Black;
            cmbCondition.DropDownStyle = ComboBoxStyle.DropDownList;


            // ———————————
            // 3) Dark/Neon Styling for CheckBoxes
            // ———————————
            foreach (var cb in new[] {
        cbUnder100, cb100to250, cb250to500, cbOver500,
        cb16gb, cb32gb, cb64gb, cb128gb,
        cb256gb, cb512gb, cb1tb, cb2tb })
            {
                cb.ForeColor = Color.Black;
                cb.BackColor = Color.White;
                cb.FlatStyle = FlatStyle.Standard;
                cb.FlatAppearance.BorderSize = 1;
                cb.FlatAppearance.BorderColor = Color.LightGray;
                cb.FlatAppearance.CheckedBackColor = Color.White;
                cb.FlatAppearance.MouseOverBackColor = Color.White;
            }


            // ———————————
            // 4) Dark/Neon Styling for Buttons
            // ———————————

            // Search button (🔍)
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.BackColor = Color.White;
            btnSearch.ForeColor = Color.Black;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            

            // Clear Filters
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.BackColor = Color.White;
            btnClearFilters.ForeColor = Color.Black;
            btnClearFilters.FlatAppearance.BorderSize = 0;
            btnClearFilters.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Prev (◀)
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.BackColor = Color.White;
            btnPrev.ForeColor = Color.Black;
            btnPrev.FlatAppearance.BorderColor = Color.FromArgb(0, 180, 220);
            btnPrev.FlatAppearance.BorderSize = 1;
            btnPrev.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPrev.Text = "◀";
            btnPrev.MouseEnter += (s, e) => btnPrev.BackColor = Color.White;
            btnPrev.MouseLeave += (s, e) => btnPrev.BackColor = Color.White;

            // Next (▶)
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.BackColor = Color.White;
            btnNext.ForeColor = Color.Black;
            btnNext.FlatAppearance.BorderColor = Color.FromArgb(0, 180, 220);
            btnNext.FlatAppearance.BorderSize = 1;
            btnNext.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNext.Text = "▶";
            btnNext.MouseEnter += (s, e) => btnNext.BackColor = Color.White;
            btnNext.MouseLeave += (s, e) => btnNext.BackColor = Color.White;

            // Page Label
            lblPage.ForeColor = Color.Black;
            lblPage.Font = new Font("Segoe UI", 9F, FontStyle.Regular);


            // ———————————
            // 5) Dark/Neon Styling for Search TextBox
            // ———————————
            txtSearch.BackColor = Color.White;
            txtSearch.ForeColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.None;
        }


        // --- 3) First‐time setup: load from DB, display, and wire filters ---
        private void shopControl_Load(object sender, EventArgs e)
        {
            flpDevices.BackColor = Color.White;
            flpDevices.AutoScroll = true;         

            _allDevices = LoadDevicesFromDb();
            _filteredDevices = _allDevices.ToList();

            // Populate Filter Boxes
            cmbType.Items.Clear();
            cmbType.Items.AddRange(
                _allDevices.Select(d => d.DeviceType)
                           .Where(s => !string.IsNullOrEmpty(s))
                           .Distinct()
                           .OrderBy(s => s)
                           .ToArray()
            );
            cmbType.SelectedIndex = -1;

            cmbOS.Items.Clear();
            cmbOS.Items.AddRange(
                _allDevices.Select(d => d.OS)
                           .Where(s => !string.IsNullOrEmpty(s))
                           .Distinct()
                           .OrderBy(s => s)
                           .ToArray()
            );
            cmbOS.SelectedIndex = -1;

            cmbCondition.Items.Clear();
            cmbCondition.Items.AddRange(
                _allDevices.Select(d => d.Condition)
                           .Where(s => !string.IsNullOrEmpty(s))
                           .Distinct()
                           .OrderBy(s => s)
                           .ToArray()
            );
            cmbCondition.SelectedIndex = -1;

            HookupFilters();
            HookupPaging();
            DisplayPage(0);
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
     // === text‐search logic (unchanged) ===
     (string.IsNullOrEmpty(term)
      || new[] { d.Brand, d.Model, d.OS, d.DeviceType }
           .Any(field =>
               !string.IsNullOrEmpty(field)
               && field.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0
           ))
     // === Type filter (use case‐insensitive match too) ===
     && (cmbType.SelectedIndex < 0
         || string.Equals(
              d.DeviceType?.Trim(),
              cmbType.Text.Trim(),
              StringComparison.OrdinalIgnoreCase
            )
        )
     // === OS filter (updated to be case‐insensitive) ===
     && (cmbOS.SelectedIndex < 0
         || string.Equals(
              d.OS?.Trim(),
              cmbOS.Text.Trim(),
              StringComparison.OrdinalIgnoreCase
            )
        )
     // === Condition filter (same deal) ===
     && (cmbCondition.SelectedIndex < 0
         || string.Equals(
              d.Condition?.Trim(),
              cmbCondition.Text.Trim(),
              StringComparison.OrdinalIgnoreCase
            )
        )
     // === price checkboxes (unchanged) ===
     && (
          (!cbUnder100.Checked && !cb100to250.Checked && !cb250to500.Checked && !cbOver500.Checked)
       || (cbUnder100.Checked && d.Price < 100M)
       || (cb100to250.Checked && d.Price >= 100M && d.Price <= 250M)
       || (cb250to500.Checked && d.Price > 250M && d.Price <= 500M)
       || (cbOver500.Checked && d.Price > 500M)
     )
     // === storage checkboxes (unchanged) ===
     && (
          (!cb16gb.Checked && !cb32gb.Checked && !cb64gb.Checked &&
           !cb128gb.Checked && !cb256gb.Checked && !cb512gb.Checked &&
           !cb1tb.Checked && !cb2tb.Checked)
       || (cb16gb.Checked && d.Storage?.Trim() == "16GB")
       || (cb32gb.Checked && d.Storage?.Trim() == "32GB")
       || (cb64gb.Checked && d.Storage?.Trim() == "64GB")
       || (cb128gb.Checked && d.Storage?.Trim() == "128GB")
       || (cb256gb.Checked && d.Storage?.Trim() == "256GB")
       || (cb512gb.Checked && d.Storage?.Trim() == "512GB")
       || (cb1tb.Checked && d.Storage?.Trim() == "1TB")
       || (cb2tb.Checked && d.Storage?.Trim() == "2TB")
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
