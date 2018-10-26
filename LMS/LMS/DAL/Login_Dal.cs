using LMS.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.DAL
{
    public class Login_Dal
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public Login_Dal()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }
        public DataTable GetLoginDetail(string UserName, string Password)
        {
            try
            {
                cmd = new SqlCommand("GetLoginDetail", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", UserName);
                sda = new SqlDataAdapter(cmd);
                cmd.Connection.Open();
                sda.Fill(dt);
                cmd.Connection.Close();

                if (dt.Rows.Count > 0)
                {
                    var pwdDB = Convert.ToString(dt.Rows[0]["Password"]);
                    var hashCode = Convert.ToString(dt.Rows[0]["Salt"]);
                    //Password Hasing Process Call Helper Class Method    
                    var encodingPasswordString = EncryptDecrypt.EncodePassword(Password, hashCode);
                    //Check Login Detail User Name Or Password    
                    if (pwdDB.Equals(encodingPasswordString))
                    {
                        return dt;
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
                else
                {
                    return new DataTable();
                }
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
    }
}