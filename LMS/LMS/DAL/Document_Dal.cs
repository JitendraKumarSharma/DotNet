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
    public class Document_Dal
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public Document_Dal()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }
        public int Save_Update_Delete_Document(string fileName, Document_Model _doc)
        {
            int id = 0;
            try
            {
                cmd = new SqlCommand("Document", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection(6);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocumentId", _doc.DocumentId);
                cmd.Parameters.AddWithValue("@DocumentPath", fileName);
                //cmd.Parameters.AddWithValue("@CreatedBy", _doc.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedBy", SessionInfo.CreatedBy);
                cmd.Parameters.AddWithValue("@Action", _doc.Action);
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

        public DataTable ViewAllDocument()
        {
            try
            {
                cmd = new SqlCommand("Getdocuments", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection(6);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocumentId", 0);
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

        public DataTable ViewDocumentById(int id)
        {
            try
            {
                cmd = new SqlCommand("Getdocuments", cmd.Connection);
                cmd.Connection = DbConnect.CreateConnection(6);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocumentId", id);
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

        public int DeleteDocument()
        {
            return 0;
        }
    }
}