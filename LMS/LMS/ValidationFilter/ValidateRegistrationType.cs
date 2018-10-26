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
    public class ValidateRegistrationType : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var Values = actionContext.ActionArguments.Values;
            int RegistrationTypeId = 0; ;
            string RegistrationTypeName = string.Empty;
            string Action = string.Empty;
            string Error = string.Empty;
            bool hasValue = false;
            foreach (RegistrationType_Model i in Values)
            {
                if (i != null)
                {
                    RegistrationTypeId = i.RegTypeId;
                    RegistrationTypeName = i.RegType;
                    Action = i.Action;
                    hasValue = true;
                }
            }

            if (hasValue == true)
            {
                if (Action != null && (Action == "update" || Action == "delete"))
                {
                    if (RegistrationTypeId == 0)
                    {
                        Error = Error + "Enter RegistrationType Id. ";
                    }
                }

                if (Action != null && (Action == "add" || Action == "update"))
                {
                    if (RegistrationTypeName == null || RegistrationTypeName == "")
                    {
                        Error = Error + "Enter RegistrationType Name. ";
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