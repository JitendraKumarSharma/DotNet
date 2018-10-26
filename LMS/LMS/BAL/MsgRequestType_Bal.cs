using LMS.DAL;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.BAL
{
    public class MsgRequestType_Bal
    {
        DataTable dt;
        private MsgRequestType_Dal obj;
        public MsgRequestType_Bal(MsgRequestType_Dal _obj)
        {
            obj = _obj;
            dt = new DataTable();
        }

        public DataTable GetAllMsgRequestType()
        {
            return obj.GetAllMsgRequestType();
        }
        public DataTable GetMsgRequestTypeById(int id)
        {
            return obj.GetMsgRequestTypeById(id);
        }
        public int Save_Update_Delete_MsgRequestType(MsgRequestType_Model _obj)
        {
            return obj.Save_Update_Delete_MsgRequestType(_obj);
        }
    }
}