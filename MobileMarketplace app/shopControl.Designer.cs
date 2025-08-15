namespace MobileMarketplace_app
{
    partial class shopControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.lblCondition = new System.Windows.Forms.Label();
            this.cmbOS = new System.Windows.Forms.ComboBox();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cbUnder100 = new System.Windows.Forms.CheckBox();
            this.cb100to250 = new System.Windows.Forms.CheckBox();
            this.cb250to500 = new System.Windows.Forms.CheckBox();
            this.cbOver500 = new System.Windows.Forms.CheckBox();
            this.cb128gb = new System.Windows.Forms.CheckBox();
            this.cb64gb = new System.Windows.Forms.CheckBox();
            this.cb32gb = new System.Windows.Forms.CheckBox();
            this.cb16gb = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb2tb = new System.Windows.Forms.CheckBox();
            this.cb1tb = new System.Windows.Forms.CheckBox();
            this.cb512gb = new System.Windows.Forms.CheckBox();
            this.cb256gb = new System.Windows.Forms.CheckBox();
            this.flpDevices = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(53, 715);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(207, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::MobileMarketplace_app.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(50, 175);
            this.lblType.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(39, 17);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type:";
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "SELECT TYPE:",
            "Phone",
            "Tablet"});
            this.cmbType.Location = new System.Drawing.Point(53, 196);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(270, 21);
            this.cmbType.TabIndex = 6;
            // 
            // cmbCondition
            // 
            this.cmbCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCondition.FormattingEnabled = true;
            this.cmbCondition.Items.AddRange(new object[] {
            "SELECT CONDITION:",
            "New",
            "Used",
            "Refurbished"});
            this.cmbCondition.Location = new System.Drawing.Point(53, 340);
            this.cmbCondition.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.cmbCondition.Name = "cmbCondition";
            this.cmbCondition.Size = new System.Drawing.Size(270, 21);
            this.cmbCondition.TabIndex = 8;
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondition.Location = new System.Drawing.Point(50, 319);
            this.lblCondition.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(70, 17);
            this.lblCondition.TabIndex = 7;
            this.lblCondition.Text = "Condition:";
            // 
            // cmbOS
            // 
            this.cmbOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOS.FormattingEnabled = true;
            this.cmbOS.Items.AddRange(new object[] {
            "SELECT OPERATING SYSTEM:",
            "Android",
            "IOS"});
            this.cmbOS.Location = new System.Drawing.Point(53, 268);
            this.cmbOS.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.cmbOS.Name = "cmbOS";
            this.cmbOS.Size = new System.Drawing.Size(270, 21);
            this.cmbOS.TabIndex = 10;
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOS.Location = new System.Drawing.Point(50, 247);
            this.lblOS.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(28, 17);
            this.lblOS.TabIndex = 9;
            this.lblOS.Text = "OS:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(50, 391);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(40, 17);
            this.lblPrice.TabIndex = 11;
            this.lblPrice.Text = "Price:";
            // 
            // cbUnder100
            // 
            this.cbUnder100.AutoSize = true;
            this.cbUnder100.Location = new System.Drawing.Point(53, 416);
            this.cbUnder100.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cbUnder100.Name = "cbUnder100";
            this.cbUnder100.Size = new System.Drawing.Size(97, 20);
            this.cbUnder100.TabIndex = 12;
            this.cbUnder100.Text = "Under $100";
            this.cbUnder100.UseVisualStyleBackColor = true;
            // 
            // cb100to250
            // 
            this.cb100to250.AutoSize = true;
            this.cb100to250.Location = new System.Drawing.Point(53, 447);
            this.cb100to250.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.cb100to250.Name = "cb100to250";
            this.cb100to250.Size = new System.Drawing.Size(95, 20);
            this.cb100to250.TabIndex = 13;
            this.cb100to250.Text = "$100 - $250";
            this.cb100to250.UseVisualStyleBackColor = true;
            // 
            // cb250to500
            // 
            this.cb250to500.AutoSize = true;
            this.cb250to500.Location = new System.Drawing.Point(165, 416);
            this.cb250to500.Margin = new System.Windows.Forms.Padding(12, 8, 3, 8);
            this.cb250to500.Name = "cb250to500";
            this.cb250to500.Size = new System.Drawing.Size(95, 20);
            this.cb250to500.TabIndex = 14;
            this.cb250to500.Text = "$250 - $500";
            this.cb250to500.UseVisualStyleBackColor = true;
            // 
            // cbOver500
            // 
            this.cbOver500.AutoSize = true;
            this.cbOver500.Location = new System.Drawing.Point(165, 452);
            this.cbOver500.Margin = new System.Windows.Forms.Padding(12, 8, 3, 8);
            this.cbOver500.Name = "cbOver500";
            this.cbOver500.Size = new System.Drawing.Size(89, 20);
            this.cbOver500.TabIndex = 15;
            this.cbOver500.Text = "Over $500";
            this.cbOver500.UseVisualStyleBackColor = true;
            // 
            // cb128gb
            // 
            this.cb128gb.AutoSize = true;
            this.cb128gb.Location = new System.Drawing.Point(53, 634);
            this.cb128gb.Margin = new System.Windows.Forms.Padding(12, 8, 3, 8);
            this.cb128gb.Name = "cb128gb";
            this.cb128gb.Size = new System.Drawing.Size(72, 20);
            this.cb128gb.TabIndex = 20;
            this.cb128gb.Text = "128 GB";
            this.cb128gb.UseVisualStyleBackColor = true;
            // 
            // cb64gb
            // 
            this.cb64gb.AutoSize = true;
            this.cb64gb.Location = new System.Drawing.Point(53, 598);
            this.cb64gb.Margin = new System.Windows.Forms.Padding(12, 8, 3, 8);
            this.cb64gb.Name = "cb64gb";
            this.cb64gb.Size = new System.Drawing.Size(65, 20);
            this.cb64gb.TabIndex = 19;
            this.cb64gb.Text = "64 GB";
            this.cb64gb.UseVisualStyleBackColor = true;
            // 
            // cb32gb
            // 
            this.cb32gb.AutoSize = true;
            this.cb32gb.Location = new System.Drawing.Point(53, 562);
            this.cb32gb.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.cb32gb.Name = "cb32gb";
            this.cb32gb.Size = new System.Drawing.Size(65, 20);
            this.cb32gb.TabIndex = 18;
            this.cb32gb.Text = "32 GB";
            this.cb32gb.UseVisualStyleBackColor = true;
            // 
            // cb16gb
            // 
            this.cb16gb.AutoSize = true;
            this.cb16gb.Location = new System.Drawing.Point(53, 531);
            this.cb16gb.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cb16gb.Name = "cb16gb";
            this.cb16gb.Size = new System.Drawing.Size(65, 20);
            this.cb16gb.TabIndex = 17;
            this.cb16gb.Text = "16 GB";
            this.cb16gb.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 506);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Storage:";
            // 
            // cb2tb
            // 
            this.cb2tb.AutoSize = true;
            this.cb2tb.Location = new System.Drawing.Point(165, 634);
            this.cb2tb.Margin = new System.Windows.Forms.Padding(12, 8, 3, 8);
            this.cb2tb.Name = "cb2tb";
            this.cb2tb.Size = new System.Drawing.Size(57, 20);
            this.cb2tb.TabIndex = 24;
            this.cb2tb.Text = "2 TB";
            this.cb2tb.UseVisualStyleBackColor = true;
            // 
            // cb1tb
            // 
            this.cb1tb.AutoSize = true;
            this.cb1tb.Location = new System.Drawing.Point(165, 598);
            this.cb1tb.Margin = new System.Windows.Forms.Padding(12, 8, 3, 8);
            this.cb1tb.Name = "cb1tb";
            this.cb1tb.Size = new System.Drawing.Size(57, 20);
            this.cb1tb.TabIndex = 23;
            this.cb1tb.Text = "1 TB";
            this.cb1tb.UseVisualStyleBackColor = true;
            // 
            // cb512gb
            // 
            this.cb512gb.AutoSize = true;
            this.cb512gb.Location = new System.Drawing.Point(165, 562);
            this.cb512gb.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.cb512gb.Name = "cb512gb";
            this.cb512gb.Size = new System.Drawing.Size(72, 20);
            this.cb512gb.TabIndex = 22;
            this.cb512gb.Text = "512 GB";
            this.cb512gb.UseVisualStyleBackColor = true;
            // 
            // cb256gb
            // 
            this.cb256gb.AutoSize = true;
            this.cb256gb.Location = new System.Drawing.Point(165, 531);
            this.cb256gb.Name = "cb256gb";
            this.cb256gb.Size = new System.Drawing.Size(72, 20);
            this.cb256gb.TabIndex = 21;
            this.cb256gb.Text = "256 GB";
            this.cb256gb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb256gb.UseVisualStyleBackColor = true;
            // 
            // flpDevices
            // 
            this.flpDevices.AutoScroll = true;
            this.flpDevices.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.flpDevices.Location = new System.Drawing.Point(400, 100);
            this.flpDevices.Name = "flpDevices";
            this.flpDevices.Size = new System.Drawing.Size(900, 600);
            this.flpDevices.TabIndex = 25;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(704, 706);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 26;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(906, 706);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(826, 713);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(39, 16);
            this.lblPage.TabIndex = 28;
            this.lblPage.Text = "page";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.AutoSize = true;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Location = new System.Drawing.Point(53, 677);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(95, 28);
            this.btnClearFilters.TabIndex = 29;
            this.btnClearFilters.Text = "Clear filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(267, 715);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // shopControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.flpDevices);
            this.Controls.Add(this.cb2tb);
            this.Controls.Add(this.cb1tb);
            this.Controls.Add(this.cb512gb);
            this.Controls.Add(this.cb256gb);
            this.Controls.Add(this.cb128gb);
            this.Controls.Add(this.cb64gb);
            this.Controls.Add(this.cb32gb);
            this.Controls.Add(this.cb16gb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbOver500);
            this.Controls.Add(this.cb250to500);
            this.Controls.Add(this.cb100to250);
            this.Controls.Add(this.cbUnder100);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cmbOS);
            this.Controls.Add(this.lblOS);
            this.Controls.Add(this.cmbCondition);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pictureBox1);
            this.Name = "shopControl";
            this.Size = new System.Drawing.Size(1540, 818);
            this.Load += new System.EventHandler(this.shopControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.ComboBox cmbOS;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.CheckBox cbUnder100;
        private System.Windows.Forms.CheckBox cb100to250;
        private System.Windows.Forms.CheckBox cb250to500;
        private System.Windows.Forms.CheckBox cbOver500;
        private System.Windows.Forms.CheckBox cb128gb;
        private System.Windows.Forms.CheckBox cb64gb;
        private System.Windows.Forms.CheckBox cb32gb;
        private System.Windows.Forms.CheckBox cb16gb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb2tb;
        private System.Windows.Forms.CheckBox cb1tb;
        private System.Windows.Forms.CheckBox cb512gb;
        private System.Windows.Forms.CheckBox cb256gb;
        private System.Windows.Forms.FlowLayoutPanel flpDevices;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Button btnSearch;
    }
}
