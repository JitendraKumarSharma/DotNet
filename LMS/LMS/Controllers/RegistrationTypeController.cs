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
    [RoutePrefix("api/RegistrationType")]
    public class RegistrationTypeController : ApiController
    {
        private RegistrationType_Bal objRegType;
        DataTable dt;

        public RegistrationTypeController(RegistrationType_Bal _obj)
        {
            objRegType = _obj;
            dt = new DataTable();
        }
        // Calling : api/RegistrationType/GetAllRegistrationType
        [HttpGet]
        [Route("GetAllRegistrationType")]
        public HttpResponseMessage GetAllRegistrationType()
        {
            dt = objRegType.GetAllRegistrationType();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // Calling : api/RegistrationType/GetRegistrationTypeById/{id}
        [HttpGet]
        [Route("GetRegistrationTypeById/{id}")]
        public HttpResponseMessage GetRegistrationTypeById(int id)
        {
            dt = objRegType.GetRegistrationTypeById(id);
            if (dt.Rows.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Registration Type not found.");
            }
        }

        // Calling : api/RegistrationType/SaveRegistrationType
        [HttpPost]
        [Route("SaveRegistrationType")]
        [ValidateRegistrationType]
        public HttpResponseMessage SaveRegistrationType(RegistrationType_Model _regType)
        {
            try
            {
                int id = objRegType.Save_Update_Delete_RegistrationType(_regType);
                if (id > 0)
                {
                    var message = Request.CreateResponse(HttpStatusCode.Created, id);
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "Registration Type already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/RegistrationType/UpdateRegistrationType
        [HttpPut]
        [Route("UpdateRegistrationType")]
        [ValidateRegistrationType]
        public HttpResponseMessage UpdateRegistrationType(RegistrationType_Model _regType)
        {
            try
            {
                int id = objRegType.Save_Update_Delete_RegistrationType(_regType);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else 
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "Registration Type already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/RegistrationType/DeleteRegistrationType
        [HttpDelete]
        [Route("DeleteRegistrationType")]
        [ValidateRegistrationType]
        public HttpResponseMessage DeleteRegistrationType(RegistrationType_Model _regType)
        {
            try
            {
                int id = objRegType.Save_Update_Delete_RegistrationType(_regType);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Registration Type not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
