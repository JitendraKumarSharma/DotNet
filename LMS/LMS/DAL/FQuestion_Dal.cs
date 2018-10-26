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
    public class FQuestion_Dal
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public FQuestion_Dal()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }
        public DataTable GetAllFQuestion()
        {
            try
            {
                cmd = new SqlCommand("Getfquestions", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FQuestionId", 0);
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
        public DataTable GetFQuestionById(int id)
        {
            try
            {
                cmd = new SqlCommand("Getfquestions", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FQuestionId", id);
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
        public int Save_Update_Delete_FQuestion(FQuestion_Model _obj)
        {
            int id = 0;
            try
            {
                cmd = new SqlCommand("Fquestion", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FQuestionId", _obj.FQuestionId);
                cmd.Parameters.AddWithValue("@FQuestion", _obj.FQuestion);
                cmd.Parameters.AddWithValue("@CreatedBy", SessionInfo.UserId);
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