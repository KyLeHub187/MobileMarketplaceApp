using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileMarketplace_app
{
    public static class UserSession
    {

        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }        // ← add this
        public static string Email { get; set; }
        public static string Phone { get; set; }        // ← add this
        public static string Gender { get; set; }        // ← or reuse Role
        public static DateTime DateOfBirth { get; set; }
        public static void Clear()
        {
            UserId = 0;
            Username = null;
            FirstName = null;
            LastName = null;
            Email = null;
            Phone = null;
            Gender = null;
        }
    }

}
