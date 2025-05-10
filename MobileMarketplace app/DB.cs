using System.Data;
using System.Data.SqlClient;

public static class DB
{
    public static readonly string ConnStr =
      "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MobileMarketplaceApp;Integrated Security=True";

    public static SqlConnection Conn => new SqlConnection(ConnStr);

    public static SqlCommand Cmd(string sql)
      => new SqlCommand(sql, Conn);

    // new helper to get any SQL into a DataTable
    public static DataTable GetTable(string sql)
    {
        var dt = new DataTable();

        using (var cmd = Cmd(sql))
        {
            cmd.Connection.Open();

            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
        }

        return dt;
    }
}
