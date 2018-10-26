using LMS.DAL;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.BAL
{
    public class Role_Bal
    {
        DataTable dt;
        private Role_Dal obj;
        public Role_Bal(Role_Dal _obj)
        {
            obj = _obj;
            dt = new DataTable();
        }

        public DataTable GetAllRole()
        {
            return obj.GetAllRole();
        }
        public DataTable GetRoleById(int id)
        {
            return obj.GetRoleById(id);
        }
        public int Save_Update_Delete_Role(Role_Model _role)
        {
            return obj.Save_Update_Delete_Role(_role);
        }
    }
}