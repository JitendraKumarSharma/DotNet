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
    public class RegistrationType_Dal
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public RegistrationType_Dal()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }
        public DataTable GetAllRegistrationType()
        {
            try
            {
                cmd = new SqlCommand("GetRegistrationType", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegTypeId", 0);
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

        public DataTable GetRegistrationTypeById(int id)
        {
            try
            {
                cmd = new SqlCommand("GetRegistrationType", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegTypeId", id);
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
        public int Save_Update_Delete_RegistrationType(RegistrationType_Model _regType)
        {
            int id = 0;
            try
            {
                cmd = new SqlCommand("RegistrationType", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegTypeId", _regType.RegTypeId);
                cmd.Parameters.AddWithValue("@RegType", _regType.RegType);
                cmd.Parameters.AddWithValue("@Action", _regType.Action);
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