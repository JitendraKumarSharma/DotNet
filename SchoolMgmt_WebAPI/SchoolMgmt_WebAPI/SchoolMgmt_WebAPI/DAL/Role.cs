using SchoolMgmt_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using dbConnect = SchoolMgmt_WebAPI.GlobalData.DbConnect;

namespace SchoolMgmt_WebAPI.DAL
{
    public class Role
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        public Role()
        {
            cmd = new SqlCommand();
            sda = new SqlDataAdapter();
            dt = new DataTable();
        }
        public IEnumerable<Mst_Role> GetAllRole()
        {
            try
            {
                cmd = new SqlCommand("GetRole")
                {
                    Connection = dbConnect.CreateConnection(),
                    CommandType = CommandType.StoredProcedure
                };
                sda = new SqlDataAdapter(cmd);
                cmd.Connection.Open();
                sda.Fill(dt);
                cmd.Connection.Close();
                IEnumerable<Mst_Role> items = dt.AsEnumerable().Select(row =>
                                                                new Mst_Role
                                                                {
                                                                    roleId = row.Field<int>("roleId"),
                                                                    roleName = row.Field<string>("roleName"),
                                                                    isActive = row.Field<bool>("isActive")
                                                                });
                return items;
            }
            catch (Exception ex)
            {
                return new List<Mst_Role>();
            }
        }
        public DataTable GetRoleById(int id)
        {
            try
            {
                cmd = new SqlCommand("GetRole")
                {
                    Connection = dbConnect.CreateConnection(),
                    CommandType = CommandType.StoredProcedure
                };
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
        public int Save_Update_Delete_Role(Mst_Role role)
        {
            int id = 0;
            try
            {
                cmd = new SqlCommand("Role")
                {
                    Connection = dbConnect.CreateConnection(),
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@RoleId", role.roleId);
                cmd.Parameters.AddWithValue("@RoleName", role.roleName);
                cmd.Parameters.AddWithValue("@IsActive", role.isActive);
                cmd.Parameters.AddWithValue("@Action", role.action);
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