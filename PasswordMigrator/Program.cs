using System;
using System.Data.SqlClient;    // ← SQL client types
using MobileMarketplace_app;    // ← your WinForms project’s namespace

namespace PasswordMigrator
{
    class Program
    {
        static void Main()
        {
            using (SqlConnection conn = DB.Conn)
            {
                conn.Open();
                Console.WriteLine("Connection opened—ready to migrate.");

                // … your SELECT/Hash/UPDATE snippet …
            }

            Console.WriteLine("Done!");
        }
    }
}
