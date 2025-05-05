using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;



namespace MobileMarketplace_app
{
    public partial class signupForm : Form
    {
        private bool dobPlaceholderActive = true;

        public signupForm()
        {
            InitializeComponent();
        }

        private void pbShown_Click(object sender, EventArgs e)
        {
            pbHidden.Visible = true;
            pbShown.Visible = false;
            txtPassword.PasswordChar = '*';
        }

        private void pbHidden_Click(object sender, EventArgs e)
        {
            pbShown.Visible = true;
            pbHidden.Visible = false;
            txtPassword.PasswordChar = '\0';
        }

        private void pcCshown_Click(object sender, EventArgs e)
        {
            pbChidden.Visible = true;
            pcCshown.Visible = false;
            txtCpassword.PasswordChar = '*';
        }

        private void pbChidden_Click(object sender, EventArgs e)
        {
            pbChidden.Visible = false;
            pcCshown.Visible = true;
            txtCpassword.PasswordChar = '\0';
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var conn = DB.Conn)
            {
                conn.Open();

                string username = txtUsername.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();

                bool userExists = false;

                string checkQuery = @"SELECT Username, Email, PhoneNumber 
                                      FROM users 
                                      WHERE Username = @u OR Email = @e OR PhoneNumber = @p";

                using (var cmd = new SqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@p", phone);

                    lblUsernameError.Visible = false;
                    lblEmailError.Visible = false;
                    lblPhoneError.Visible = false;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["Username"].ToString() == username)
                                lblUsernameError.Visible = true;

                            if (reader["Email"].ToString() == email)
                                lblEmailError.Visible = true;

                            if (reader["PhoneNumber"].ToString() == phone)
                                lblPhoneError.Visible = true;

                            userExists = true;
                        }
                    }
                }

                if (userExists)
                    return;

                string insertQuery = @"
    INSERT INTO users 
    (Username, PasswordHash, Email, PhoneNumber, FirstName, LastName, DateOfBirth, Gender) 
    VALUES 
    (@u, @pw, @e, @p, @fn, @ln, @dob, @gender)";

                using (var insertCmd = new SqlCommand(insertQuery, conn))
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text.Trim());

                    insertCmd.Parameters.AddWithValue("@u", username);
                    insertCmd.Parameters.AddWithValue("@pw", hashedPassword);
                    insertCmd.Parameters.AddWithValue("@e", email);
                    insertCmd.Parameters.AddWithValue("@p", phone);
                    insertCmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@dob", dtpDOB.Value.Date);
                    insertCmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem?.ToString() ?? "");

                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Congrats!! Account Created Successfully. Please log in!", "Success");

                this.Hide();
                new loginForm().Show();
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

    }
}
