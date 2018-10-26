using LMS.DAL;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.BAL
{
    public class Registration_Bal
    {
        DataTable dt;
        private Registration_Dal objReg;
        public Registration_Bal(Registration_Dal _obj)
        {
            objReg = _obj;
            dt = new DataTable();
        }

        public DataTable GetAllUser()
        {
            dt = objReg.GetAllUser();
            return dt;
        }
        public DataTable GetUserById(int id)
        {
            dt = objReg.GetUserById(id);
            return dt;
        }

        public int Save_Update_User(Registration_Model _reg)
        {
            return objReg.Save_Update_User(_reg);
        }

        public int Delete_User(int id)
        {
            return objReg.Delete_User(id);
        }
    }
}