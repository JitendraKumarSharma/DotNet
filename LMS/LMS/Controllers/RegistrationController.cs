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
    [RoutePrefix("api/register")]
    public class RegistrationController : ApiController
    {
        private Registration_Bal objReg;
        DataTable dt;

        public RegistrationController(Registration_Bal _obj)
        {
            objReg = _obj;
        }
        // Calling : api/register/getalluser
        [HttpGet]
        [Route("getalluser")]
        public HttpResponseMessage GetAllUser()
        {
            dt = objReg.GetAllUser();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // Calling : api/register/getuserbyid/{id}
        [HttpGet]
        [Route("getuserbyid/{id}")]
        public HttpResponseMessage GetUserById(int id)
        {
            dt = objReg.GetUserById(id);
            if (dt.Rows.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found.");
            }
        }

        // Calling : api/register/saveuser
        [AllowAnonymous]
        [HttpPost]
        [Route("saveuser")]
        [ValidateRegistration]
        public HttpResponseMessage SaveUser(Registration_Model _reg)
        {
            try
            {
                int id = objReg.Save_Update_User(_reg);
                if (id > 0)
                {
                    var message = Request.CreateResponse(HttpStatusCode.Created, id);
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "User already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/register/updateuser
        [HttpPut]
        [Route("updateuser")]
        [ValidateRegistration]
        public HttpResponseMessage UpdateUser(Registration_Model _reg)
        {
            try
            {
                int id = objReg.Save_Update_User(_reg);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "User already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // Calling : api/register/deleteuser/{id}
        [HttpDelete]
        [Route("deleteuser/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                int cnt = objReg.Delete_User(id);
                if (cnt > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, cnt);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
