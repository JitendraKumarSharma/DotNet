using LMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.BAL
{
    public class Login_Bal
    {
        DataTable dt;
        private Login_Dal objLogin;
        public Login_Bal(Login_Dal _obj)
        {
            objLogin = _obj;
            dt = new DataTable();
        }

        public DataTable GetLoginDetail(string UserName, string Password)
        {
            dt = objLogin.GetLoginDetail(UserName, Password);
            return dt;
        }
    }
}