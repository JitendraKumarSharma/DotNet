using System.Configuration;
using System.Data.SqlClient;

namespace SchoolMgmt_WebAPI.GlobalData
{
    public static class DbConnect
    {
        public static SqlConnection CreateConnection(int roleId = 0)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
        }
    }
}