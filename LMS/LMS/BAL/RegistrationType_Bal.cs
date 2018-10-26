using LMS.DAL;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.BAL
{
    public class RegistrationType_Bal
    {
        DataTable dt;
        private RegistrationType_Dal obj;
        public RegistrationType_Bal(RegistrationType_Dal _obj)
        {
            obj = _obj;
            dt = new DataTable();
        }

        public DataTable GetAllRegistrationType()
        {
            dt = obj.GetAllRegistrationType();
            return dt;
        }

        public DataTable GetRegistrationTypeById(int id)
        {
            dt = obj.GetRegistrationTypeById(id);
            return dt;
        }

        public int Save_Update_Delete_RegistrationType(RegistrationType_Model _regType)
        {
            return obj.Save_Update_Delete_RegistrationType(_regType);
        }
    }
}