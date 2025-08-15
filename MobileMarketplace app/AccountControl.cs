using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMarketplace_app
{
    public partial class AccountControl : UserControl
    {
        public AccountControl()
        {
            InitializeComponent();
        }

        public void LoadUser()
        {

            txtUsername.Text = UserSession.Username;
            txtName.Text = UserSession.FirstName;
            txtSurname.Text = UserSession.LastName;
            txtEmail.Text = UserSession.Email;
            txtPhone.Text = UserSession.Phone;
            cmbGender.SelectedItem = UserSession.Gender;

            // clamp before you assign
            var dob = UserSession.DateOfBirth;
            if (dob < dtpDob.MinDate) dob = dtpDob.MinDate;
            else if (dob > dtpDob.MaxDate) dob = dtpDob.MaxDate;
            dtpDob.Value = dob;
        }
    }
}
