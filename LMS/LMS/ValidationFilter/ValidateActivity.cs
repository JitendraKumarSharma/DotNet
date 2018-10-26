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
    public class ValidateActivity : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var Values = actionContext.ActionArguments.Values;
            int ActivityId = 0; ;
            string ActivityName = string.Empty;
            string Action = string.Empty;
            string Error = string.Empty;
            bool hasValue = false;

            foreach (Activity_Model i in Values)
            {
                if (i != null)
                {
                    ActivityId = i.ActivityId;
                    ActivityName = i.Activity;
                    Action = i.Action;
                    hasValue = true;
                }
            }

            if (hasValue == true)
            {
                if (Action != null && (Action == "update" || Action == "delete"))
                {
                    if (ActivityId == 0)
                    {
                        Error = Error + "Enter Activity Id. ";
                    }
                }

                if (Action != null && (Action == "add" || Action == "update"))
                {
                    if (ActivityName == null || ActivityName == "")
                    {
                        Error = Error + "Enter Activity Name. ";
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

            //if (actionContext.ModelState.IsValid == false)
            //{
            //    actionContext.Response = actionContext.Request.CreateErrorResponse(
            //        HttpStatusCode.BadRequest, actionContext.ModelState);
            //}
        }
    }
}