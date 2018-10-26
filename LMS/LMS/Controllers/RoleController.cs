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
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        private Role_Bal objRole;
        DataTable dt;

        public RoleController(Role_Bal _obj)
        {
            objRole = _obj;
            dt = new DataTable();
        }

        // Calling : api/role/getallrole
        [HttpGet]
        [Route("getallrole")]
        public HttpResponseMessage GetAllRole()
        {
            dt = objRole.GetAllRole();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // Calling : api/role/getrolebyid/{id}
        [HttpGet]
        [Route("getrolebyid/{id}")]
        public HttpResponseMessage GetRoleById(int id)
        {
            dt = objRole.GetRoleById(id);
            if (dt.Rows.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Role not found.");
            }
        }

        // Calling : api/role/saverole
        [HttpPost]
        [Route("saverole")]
        [ValidateRole]
        public HttpResponseMessage SaveRole(Role_Model _role)
        {
            try
            {
                int id = objRole.Save_Update_Delete_Role(_role);
                if (id > 0)
                {
                    var message = Request.CreateResponse(HttpStatusCode.Created, id);
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "Role already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/role/updaterole
        [HttpPut]
        [Route("updaterole")]
        [ValidateRole]
        public HttpResponseMessage UpdateRole(Role_Model _role)
        {
            try
            {
                int id = objRole.Save_Update_Delete_Role(_role);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "Role already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/role/deleterole
        [HttpDelete]
        [Route("deleterole")]
        [ValidateRole]
        public HttpResponseMessage DeleteRole(Role_Model _role)
        {
            try
            {
                int id = objRole.Save_Update_Delete_Role(_role);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Role not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
