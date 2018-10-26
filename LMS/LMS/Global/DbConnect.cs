using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
namespace LMS.Global
{
    public static class DbConnect
    {
        public static SqlConnection CreateConnection(int roleId = 0)
        {
            if (roleId == 0)
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
            }
            else
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionOrg"].ConnectionString.ToString());
            }
        }
    }
}