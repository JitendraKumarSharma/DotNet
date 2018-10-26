using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LMS.ValidationFilter
{
    public class ValidateMsgRequestType : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var Values = actionContext.ActionArguments.Values;
            int MsgTypeId = 0; ;
            string MsgRequestType = string.Empty;
            string Action = string.Empty;
            string Error = string.Empty;
            bool hasValue = false;
            foreach (MsgRequestType_Model i in Values)
            {
                if (i != null)
                {
                    MsgTypeId = i.MsgTypeId;
                    MsgRequestType = i.MsgRequestType;
                    Action = i.Action;
                    hasValue = true;
                }
            }

            if (hasValue == true)
            {
                if (Action != null && (Action == "update" || Action == "delete"))
                {
                    if (MsgTypeId == 0)
                    {
                        Error = Error + "Enter MsgType Id. ";
                    }
                }

                if (Action != null && (Action == "add" || Action == "update"))
                {
                    if (MsgRequestType == null || MsgRequestType == "")
                    {
                        Error = Error + "Enter MsgRequestType Name. ";
                    }
                }

                if (Error != "")
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, Error);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.BadRequest, "Enter all the required fields");
            }
        }
    }
}