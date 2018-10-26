using LMS.BAL;
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
    [RoutePrefix("api/FQuestion")]
    public class FQuestionController : ApiController
    {
        private FQuestion_Bal obj;
        DataTable dt;

        public FQuestionController(FQuestion_Bal _obj)
        {
            obj = _obj;
        }

        // Calling : api/FQuestion/getallFQuestion
        [HttpGet]
        [Route("getallFQuestion")]
        public HttpResponseMessage GetAllFQuestion()
        {
            dt = obj.GetAllFQuestion();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // Calling : api/FQuestion/getFQuestionbyid/{id}
        [HttpGet]
        [Route("getFQuestionbyid/{id}")]
        public HttpResponseMessage GetFQuestionById(int id)
        {
            dt = obj.GetFQuestionById(id);
            if (dt.Rows.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "FQuestion not found.");
            }
        }

        // Calling : api/FQuestion/saveFQuestion
        [HttpPost]
        [Route("saveFQuestion")]
        [ValidateFQuestion]
        public HttpResponseMessage SaveFQuestion(FQuestion_Model _obj)
        {
            try
            {
                int id = obj.Save_Update_Delete_FQuestion(_obj);
                if (id > 0)
                {
                    var message = Request.CreateResponse(HttpStatusCode.Created, id);
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "FQuestion already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/FQuestion/updateFQuestion
        [HttpPut]
        [Route("updateFQuestion")]
        [ValidateFQuestion]
        public HttpResponseMessage UpdateFQuestion(FQuestion_Model _obj)
        {
            try
            {
                int id = obj.Save_Update_Delete_FQuestion(_obj);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "FQuestion already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/FQuestion/deleteFQuestion
        [HttpDelete]
        [Route("deleteFQuestion")]
        [ValidateFQuestion]
        public HttpResponseMessage DeleteFQuestion(FQuestion_Model _obj)
        {
            try
            {
                int id = obj.Save_Update_Delete_FQuestion(_obj);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "FQuestion not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
