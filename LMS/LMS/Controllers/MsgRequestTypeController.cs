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
    [RoutePrefix("api/MsgRequestType")]
    public class MsgRequestTypeController : ApiController
    {
        private MsgRequestType_Bal obj;
        DataTable dt;

        public MsgRequestTypeController(MsgRequestType_Bal _obj)
        {
            obj = _obj;
        }

        // Calling : api/MsgRequestType/getallMsgRequestType
        [HttpGet]
        [Route("getallMsgRequestType")]
        public HttpResponseMessage GetAllMsgRequestType()
        {
            dt = obj.GetAllMsgRequestType();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // Calling : api/MsgRequestType/getMsgRequestTypebyid/{id}
        [HttpGet]
        [Route("getMsgRequestTypebyid/{id}")]
        public HttpResponseMessage GetMsgRequestTypeById(int id)
        {
            dt = obj.GetMsgRequestTypeById(id);
            if (dt.Rows.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Msg Request Type not found.");
            }
        }

        // Calling : api/MsgRequestType/saveMsgRequestType
        [HttpPost]
        [Route("saveMsgRequestType")]
        [ValidateMsgRequestType]
        public HttpResponseMessage SavesMsgRequestType(MsgRequestType_Model _obj)
        {
            try
            {
                int id = obj.Save_Update_Delete_MsgRequestType(_obj);
                if (id > 0)
                {
                    var message = Request.CreateResponse(HttpStatusCode.Created, id);
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "Msg Request Type already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/MsgRequestType/updateMsgRequestType
        [HttpPut]
        [Route("updateMsgRequestType")]
        [ValidateMsgRequestType]
        public HttpResponseMessage UpdateMsgRequestType(MsgRequestType_Model _obj)
        {
            try
            {
                int id = obj.Save_Update_Delete_MsgRequestType(_obj);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.MultipleChoices, "Msg Request Type already exists");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/MsgRequestType/deleteMsgRequestType
        [HttpDelete]
        [Route("deleteMsgRequestType")]
        [ValidateMsgRequestType]
        public HttpResponseMessage DeleteMsgRequestType(MsgRequestType_Model _obj)
        {
            try
            {
                int id = obj.Save_Update_Delete_MsgRequestType(_obj);
                if (id > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Msg Request Type not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
