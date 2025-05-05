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
        public static string Email { get; set; }
        public static string Role { get; set; } // Optional, if you store roles

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Email = null;
            Role = null;
        }
    }

}
