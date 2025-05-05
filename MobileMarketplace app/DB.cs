using System.Data.SqlClient;

public static class DB
{
    public static readonly string ConnStr = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MobileMarketplaceApp;Integrated Security=True";

    public static SqlConnection Conn => new SqlConnection(ConnStr);

    public static SqlCommand Cmd(string sql)
    {
        return new SqlCommand(sql, Conn);
    }
}
