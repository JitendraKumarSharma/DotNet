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
    public class Registration_Dal
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public Registration_Dal()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }
        public DataTable GetAllUser()
        {
            try
            {
                cmd = new SqlCommand("Getusers", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", 0);
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
        public DataTable GetUserById(int id)
        {
            try
            {
                cmd = new SqlCommand("Getusers", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", id);
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
        public int Save_Update_User(Registration_Model _reg)
        {
            int id = 0;
            try
            {
                //string Password = EncryptDecrypt.Encrypt(_reg.Password.ToString());
                var keyNew = EncryptDecrypt.GeneratePassword(10);
                var Password = EncryptDecrypt.EncodePassword(_reg.Password, keyNew);
                cmd = new SqlCommand("Addupdateuser", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", _reg.UserId);
                cmd.Parameters.AddWithValue("@UserName", _reg.UserName);
                cmd.Parameters.AddWithValue("@RoleId", _reg.RoleId);
                cmd.Parameters.AddWithValue("@Address", _reg.Address);
                cmd.Parameters.AddWithValue("@EmailId", _reg.EmailId);
                cmd.Parameters.AddWithValue("@ContactNo", _reg.ContactNo);
                cmd.Parameters.AddWithValue("@DatabaseId", _reg.DatabaseId);
                cmd.Parameters.AddWithValue("@password", Password);
                cmd.Parameters.AddWithValue("@RegistrationType", _reg.RegistrationType);
                cmd.Parameters.AddWithValue("@CreatedBy", _reg.CreatedBy);
                cmd.Parameters.AddWithValue("@Action", _reg.Action);
                cmd.Parameters.AddWithValue("@Salt", keyNew);
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
        public int Delete_User(int id)
        {
            try
            {
                cmd = new SqlCommand("DeleteUser", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", id);
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