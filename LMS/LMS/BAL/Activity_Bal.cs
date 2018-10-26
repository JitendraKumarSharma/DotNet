using LMS.DAL;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.BAL
{
    public class Activity_Bal
    {
        DataTable dt;
        private Activity_Dal obj;
        public Activity_Bal(Activity_Dal _obj)
        {
            obj = _obj;
            dt = new DataTable();
        }

        public DataTable GetAllActivity()
        {
            return obj.GetAllActivity();
        }
        public DataTable GetActivityById(int id)
        {
            return obj.GetActivityById(id);
        }
        public int Save_Update_Delete_Activity(Activity_Model _act)
        {
            return obj.Save_Update_Delete_Activity(_act);
        }
    }
}