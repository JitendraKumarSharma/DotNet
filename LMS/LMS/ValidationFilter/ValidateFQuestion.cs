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
    public class ValidateFQuestion : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var Values = actionContext.ActionArguments.Values;
            int FQuestionId = 0;
            string FQuestion = string.Empty;
            int CreatedBy = 0;
            string Action = string.Empty;
            string Error = string.Empty;
            bool hasValue = false;

            foreach (FQuestion_Model i in Values)
            {
                if (i != null)
                {
                    FQuestionId = i.FQuestionId;
                    FQuestion = i.FQuestion;
                    CreatedBy = i.CreatedBy;
                    Action = i.Action;
                    hasValue = true;
                }
            }

            if (hasValue == true)
            {
                if (Action != null && (Action == "update" || Action == "delete"))
                {
                    if (FQuestionId == 0)
                    {
                        Error = Error + "Enter FQuestion Id. ";
                    }
                }

                if (Action != null && (Action == "add" || Action == "update"))
                {
                    if (FQuestion == null || FQuestion == "")
                    {
                        Error = Error + "Enter FQuestion Name. ";
                    }
                    if (CreatedBy == 0)
                    {
                        Error = Error + "Enter CreatedBy Id. ";
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