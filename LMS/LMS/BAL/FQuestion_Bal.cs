using LMS.DAL;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.BAL
{
    public class FQuestion_Bal
    {
        DataTable dt;
        private FQuestion_Dal obj;
        public FQuestion_Bal(FQuestion_Dal _obj)
        {
            obj = _obj;
            dt = new DataTable();
        }
        public DataTable GetAllFQuestion()
        {
            return obj.GetAllFQuestion();
        }
        public DataTable GetFQuestionById(int id)
        {
            return obj.GetFQuestionById(id);
        }
        public int Save_Update_Delete_FQuestion(FQuestion_Model _obj)
        {
            return obj.Save_Update_Delete_FQuestion(_obj);
        }

    }
}