using LMS.Global;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.DAL
{
    public class Role_Dal
    {
        //public static JsonSerializerSettings settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateFormatHandling = DateFormatHandling.IsoDateFormat };
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public Role_Dal()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }

        public DataTable GetAllRole()
        {
            //int a = 10;
            //int b = 0;
            //int c = a / b;
            try
            {
                cmd = new SqlCommand("GetRole", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleId", 0);
                sda = new SqlDataAdapter(cmd);
                cmd.Connection.Open();
                sda.Fill(dt);
                cmd.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
        public DataTable GetRoleById(int id)
        {
            try
            {
                cmd = new SqlCommand("GetRole", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleId", id);
                sda = new SqlDataAdapter(cmd);
                cmd.Connection.Open();
                sda.Fill(dt);
                cmd.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
        public int Save_Update_Delete_Role(Role_Model _role)
        {
            int id = 0;
            try
            {
                cmd = new SqlCommand("Role", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleId", _role.RoleId);
                cmd.Parameters.AddWithValue("@Role", _role.Role);
                cmd.Parameters.AddWithValue("@Action", _role.Action);
                cmd.Connection.Open();
                id = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
                return id;
            }
            catch (Exception ex)
            {
                return id;
            }
        }
    }
}