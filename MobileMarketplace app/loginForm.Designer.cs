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
            this.panelUsernameShadow = new System.Windows.Forms.Panel();
            this.panelUsernameInput = new System.Windows.Forms.Panel();
            this.pbUsernameIcon = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignup = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbShown = new System.Windows.Forms.PictureBox();
            this.pbHidden = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelUsernameInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsernameIcon)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(534, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 596);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 31, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // panelUsernameShadow
            // 
            this.panelUsernameShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelUsernameShadow.Location = new System.Drawing.Point(233, 143);
            this.panelUsernameShadow.Margin = new System.Windows.Forms.Padding(4);
            this.panelUsernameShadow.Name = "panelUsernameShadow";
            this.panelUsernameShadow.Size = new System.Drawing.Size(197, 25);
            this.panelUsernameShadow.TabIndex = 5;
            // 
            // panelUsernameInput
            // 
            this.panelUsernameInput.BackColor = System.Drawing.Color.White;
            this.panelUsernameInput.Controls.Add(this.pbUsernameIcon);
            this.panelUsernameInput.Controls.Add(this.txtUsername);
            this.panelUsernameInput.Location = new System.Drawing.Point(236, 145);
            this.panelUsernameInput.Margin = new System.Windows.Forms.Padding(4);
            this.panelUsernameInput.Name = "panelUsernameInput";
            this.panelUsernameInput.Padding = new System.Windows.Forms.Padding(25, 2, 3, 2);
            this.panelUsernameInput.Size = new System.Drawing.Size(197, 25);
            this.panelUsernameInput.TabIndex = 1;
            // 
            // pbUsernameIcon
            // 
            this.pbUsernameIcon.Image = global::MobileMarketplace_app.Properties.Resources.user;
            this.pbUsernameIcon.Location = new System.Drawing.Point(1, 2);
            this.pbUsernameIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pbUsernameIcon.Name = "pbUsernameIcon";
            this.pbUsernameIcon.Size = new System.Drawing.Size(21, 20);
            this.pbUsernameIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUsernameIcon.TabIndex = 0;
            this.pbUsernameIcon.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Location = new System.Drawing.Point(25, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(169, 15);
            this.txtUsername.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(344, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Forgot Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(343, 260);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(233, 260);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(75, 23);
            this.btnSignup.TabIndex = 8;
            this.btnSignup.Text = "Sign Up";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pbShown);
            this.panel2.Controls.Add(this.pbHidden);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(236, 192);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(25, 2, 3, 2);
            this.panel2.Size = new System.Drawing.Size(197, 25);
            this.panel2.TabIndex = 2;
            // 
            // pbShown
            // 
            this.pbShown.Image = global::MobileMarketplace_app.Properties.Resources.Passwordshown;
            this.pbShown.Location = new System.Drawing.Point(175, 6);
            this.pbShown.Name = "pbShown";
            this.pbShown.Size = new System.Drawing.Size(16, 16);
            this.pbShown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShown.TabIndex = 13;
            this.pbShown.TabStop = false;
            this.pbShown.Visible = false;
            this.pbShown.Click += new System.EventHandler(this.pbShown_Click);
            // 
            // pbHidden
            // 
            this.pbHidden.Image = global::MobileMarketplace_app.Properties.Resources.hidden;
            this.pbHidden.Location = new System.Drawing.Point(175, 6);
            this.pbHidden.Name = "pbHidden";
            this.pbHidden.Size = new System.Drawing.Size(16, 16);
            this.pbHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHidden.TabIndex = 12;
            this.pbHidden.TabStop = false;
            this.pbHidden.Click += new System.EventHandler(this.pbHidden_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(25, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(169, 15);
            this.txtPassword.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MobileMarketplace_app.Properties.Resources.locked_computer;
            this.pictureBox2.Location = new System.Drawing.Point(1, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel3.Location = new System.Drawing.Point(233, 190);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(197, 25);
            this.panel3.TabIndex = 6;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(770, 626);
            this.Controls.Add(this.panelUsernameInput);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelUsernameShadow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "loginForm";
            this.Text = "loginForm";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.panelUsernameInput.ResumeLayout(false);
            this.panelUsernameInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsernameIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panelUsernameShadow;
        private System.Windows.Forms.Panel panelUsernameInput;
        private System.Windows.Forms.PictureBox pbUsernameIcon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbHidden;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox pbShown;
    }
}