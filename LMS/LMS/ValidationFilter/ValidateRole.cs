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
    public class ValidateRole : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var Values = actionContext.ActionArguments.Values;
            int RoleId = 0; ;
            string RoleName = string.Empty;
            string Action = string.Empty;
            string Error = string.Empty;
            bool hasValue = false;
            foreach (Role_Model i in Values)
            {
                if (i != null)
                {
                    RoleId = i.RoleId;
                    RoleName = i.Role;
                    Action = i.Action;
                    hasValue = true;
                }
            }

            if (hasValue == true)
            {
                if (Action != null && (Action == "update" || Action == "delete"))
                {
                    if (RoleId == 0)
                    {
                        Error = Error + "Enter Role Id. ";
                    }
                }

                if (Action != null && (Action == "add" || Action == "update"))
                {
                    if (RoleName == null || RoleName == "")
                    {
                        Error = Error + "Enter Role Name. ";
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