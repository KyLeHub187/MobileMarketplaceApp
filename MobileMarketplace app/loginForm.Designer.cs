namespace MobileMarketplace_app
{
    partial class loginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panelUsernameShadow = new System.Windows.Forms.Panel();
            this.panelUsernameInput = new System.Windows.Forms.Panel();
            this.pbUsernameIcon = new System.Windows.Forms.PictureBox();
            this.panelUsernameInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsernameIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(350, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 485);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 25, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(175, 154);
            this.textBox2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 4;
            // 
            // panelUsernameShadow
            // 
            this.panelUsernameShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelUsernameShadow.Location = new System.Drawing.Point(175, 116);
            this.panelUsernameShadow.Name = "panelUsernameShadow";
            this.panelUsernameShadow.Size = new System.Drawing.Size(120, 20);
            this.panelUsernameShadow.TabIndex = 5;
            // 
            // panelUsernameInput
            // 
            this.panelUsernameInput.BackColor = System.Drawing.Color.White;
            this.panelUsernameInput.Controls.Add(this.pbUsernameIcon);
            this.panelUsernameInput.Location = new System.Drawing.Point(177, 118);
            this.panelUsernameInput.Name = "panelUsernameInput";
            this.panelUsernameInput.Padding = new System.Windows.Forms.Padding(30, 2, 2, 2);
            this.panelUsernameInput.Size = new System.Drawing.Size(120, 20);
            this.panelUsernameInput.TabIndex = 0;
            // 
            // pbUsernameIcon
            // 
            this.pbUsernameIcon.Image = global::MobileMarketplace_app.Properties.Resources.user;
            this.pbUsernameIcon.Location = new System.Drawing.Point(1, 2);
            this.pbUsernameIcon.Name = "pbUsernameIcon";
            this.pbUsernameIcon.Size = new System.Drawing.Size(16, 16);
            this.pbUsernameIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUsernameIcon.TabIndex = 0;
            this.pbUsernameIcon.TabStop = false;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(495, 509);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelUsernameInput);
            this.Controls.Add(this.panelUsernameShadow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "loginForm";
            this.Text = "loginForm";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.panelUsernameInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUsernameIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panelUsernameShadow;
        private System.Windows.Forms.Panel panelUsernameInput;
        private System.Windows.Forms.PictureBox pbUsernameIcon;
    }
}