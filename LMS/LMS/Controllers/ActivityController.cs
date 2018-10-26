using LMS.BAL;
using LMS.ExceptionHandle;
using LMS.Models;
using LMS.ValidationFilter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    [Authorize]
    [RoutePrefix("api/activity")]
    public class ActivityController : ApiController
    {
        private Activity_Bal obj;
        DataTable dt;
        public ActivityController(Activity_Bal _obj)
        {
            obj = _obj;
            dt = new DataTable();
        }

        // Calling : api/activity/GetAllActivity
        [HttpGet]
        [Route("GetAllActivity")]
        public HttpResponseMessage GetAllActivity()
        {
            dt = obj.GetAllActivity();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // Calling : api/activity/GetActivityById/{id}
        [HttpGet]
        [Route("GetActivityById/{id}")]
        public HttpResponseMessage GetActivityById(int id)
        {
            dt = obj.GetActivityById(id);
            if (dt.Rows.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Activity not found.");
            }
        }

        // Calling : api/activity/SaveActivity
        [HttpPost]
        [Route("SaveActivity")]
        [ValidateActivity]
        public HttpResponseMessage SaveActivity(Activity_Model _act)
        {
            try
            {
                int id = obj.Save_Update_Delete_Activity(_act);
                if (id > 0)
                {
                    var message = Request.CreateResponse(HttpStatusCode.Created, id);
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "Activity already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/activity/UpdateActivity
        [HttpPut]
        [Route("UpdateActivity")]
        [ValidateActivity]
        public HttpResponseMessage UpdateActivity(Activity_Model _act)
        {
            try
            {
                int id = obj.Save_Update_Delete_Activity(_act);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "Activity already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/activity/DeleteActivity
        [HttpDelete]
        [Route("DeleteActivity")]
        [ValidateActivity]
        public HttpResponseMessage DeleteActivity(Activity_Model _act)
        {
            try
            {
                int id = obj.Save_Update_Delete_Activity(_act);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Activity not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
