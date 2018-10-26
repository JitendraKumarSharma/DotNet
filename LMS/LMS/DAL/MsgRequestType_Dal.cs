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
    public class MsgRequestType_Dal
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public MsgRequestType_Dal()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }
        public DataTable GetAllMsgRequestType()
        {
            try
            {
                cmd = new SqlCommand("Getmsgrequesttype", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MsgTypeId", 0);
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
        public DataTable GetMsgRequestTypeById(int id)
        {
            try
            {
                cmd = new SqlCommand("Getmsgrequesttype", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MsgTypeId", id);
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
        public int Save_Update_Delete_MsgRequestType(MsgRequestType_Model _obj)
        {
            int id = 0;
            try
            {
                cmd = new SqlCommand("MsgRequestType", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MsgTypeId", _obj.MsgTypeId);
                cmd.Parameters.AddWithValue("@MsgRequestType", _obj.MsgRequestType);
                cmd.Parameters.AddWithValue("@Action", _obj.Action);
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