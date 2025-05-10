namespace MobileMarketplace_app
{
    partial class deviceCard
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCondition = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDateAdded = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblCondition
            // 
            this.lblCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCondition.ForeColor = System.Drawing.Color.Green;
            this.lblCondition.Location = new System.Drawing.Point(5, 184);
            this.lblCondition.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(138, 24);
            this.lblCondition.TabIndex = 1;
            this.lblCondition.Text = "Condition";
            this.lblCondition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrand
            // 
            this.lblBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(5, 105);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(138, 31);
            this.lblBrand.TabIndex = 2;
            this.lblBrand.Text = "Brand";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblModel
            // 
            this.lblModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblModel.Location = new System.Drawing.Point(5, 136);
            this.lblModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(138, 24);
            this.lblModel.TabIndex = 3;
            this.lblModel.Text = "Model";
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPrice.Location = new System.Drawing.Point(5, 160);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(138, 24);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateAdded
            // 
            this.lblDateAdded.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDateAdded.ForeColor = System.Drawing.Color.DimGray;
            this.lblDateAdded.Location = new System.Drawing.Point(5, 208);
            this.lblDateAdded.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblDateAdded.Name = "lblDateAdded";
            this.lblDateAdded.Size = new System.Drawing.Size(138, 24);
            this.lblDateAdded.TabIndex = 5;
            this.lblDateAdded.Text = "Date Added";
            this.lblDateAdded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deviceCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblDateAdded);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.pictureBox1);
            this.Name = "deviceCard";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(148, 248);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDateAdded;
    }
}
