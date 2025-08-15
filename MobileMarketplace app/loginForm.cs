using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;


namespace MobileMarketplace_app
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pbHidden_Click(object sender, EventArgs e)
        {
            pbHidden.Visible = false;
            pbShown.Visible = true;
            txtPassword.PasswordChar = '\0';
        }

        private void pbShown_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            pbHidden.Visible = true;
            pbShown.Visible = false;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            signupForm signup = new signupForm();
            signup.ShowDialog(); // Changed from Show() to ShowDialog() to fix the error
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (var conn = DB.Conn)
            {
                conn.Open();

                string query = "SELECT * FROM users WHERE Username = @u";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                            {
                                // Successful login
                                UserSession.UserId = Convert.ToInt32(reader["UserId"]);
                                UserSession.Username = reader["Username"].ToString();
                                UserSession.Email = reader["Email"].ToString();
                                UserSession.Gender = reader["Role"]?.ToString();
                                UserSession.FirstName = reader["FirstName"].ToString();


                                this.Hide();
                                var main = new mainForm();
                                main.Show();
                                homeControl home = new homeControl();
                            }
                            else
                            {
                                MessageBox.Show("Invalid password.", "Login Failed");
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found.", "Login Failed");
                        }
                    }
                }
            }
        }

    }
}
