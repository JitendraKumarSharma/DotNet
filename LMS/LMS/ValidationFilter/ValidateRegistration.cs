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
    public class ValidateRegistration : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var Values = actionContext.ActionArguments.Values;
            int UserId = 0;
            string UserName = string.Empty;
            int RoleId = 0;
            string EmailId = string.Empty;
            string ContactNo = string.Empty;
            int DatabaseId = 0;
            string Password = string.Empty;
            int RegistrationType = 0;
            DateTime CreatedOn = new DateTime(1900, 01, 01);
            string Action = string.Empty;
            string Error = string.Empty;
            bool hasValue = false;

            foreach (Registration_Model i in Values)
            {
                if (i != null)
                {
                    UserId = i.UserId;
                    UserName = i.UserName;
                    RoleId = i.RoleId;
                    EmailId = i.EmailId;
                    ContactNo = i.ContactNo;
                    DatabaseId = i.DatabaseId;
                    Password = i.Password;
                    RegistrationType = i.RegistrationType;
                    Action = i.Action;
                    hasValue = true;
                }
            }
            if (hasValue == true)
            {
                if (Action != null && Action == "update")
                {
                    if (UserId == 0)
                    {
                        Error = Error + "Enter User Id. ";
                    }
                }

                if (Action != null && (Action == "update" || Action == "add"))
                {
                    if (UserName == null || UserName == "")
                    {
                        Error = Error + "Enter User Name. ";
                    }
                    if (RoleId == 0)
                    {
                        Error = Error + "Enter Role Id. ";
                    }
                    if (EmailId == null || EmailId == "")
                    {
                        Error = Error + "Enter EmailId. ";
                    }
                    if (ContactNo == null || ContactNo == "")
                    {
                        Error = Error + "Enter Contact Number. ";
                    }
                    if (DatabaseId == 0)
                    {
                        Error = Error + "Enter Database Id. ";
                    }
                    if (Password == null || Password == "")
                    {
                        Error = Error + "Enter Password. ";
                    }
                    if (RegistrationType == 0)
                    {
                        Error = Error + "Enter Registration Type Id. ";
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