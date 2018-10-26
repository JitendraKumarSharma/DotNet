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
using System.Web;
using System.Web.Http;

namespace LMS.Controllers
{
    [Authorize]
    [RoutePrefix("api/document")]
    public class DocumentController : ApiController
    {
        private Document_Bal obj;
        DataTable dt;
        public DocumentController(Document_Bal _obj)
        {
            obj = _obj;
            dt = new DataTable();
        }

        // Calling : api/document/viewalldocument
        [HttpGet]
        [Route("viewalldocument")]
        public HttpResponseMessage ViewAllDocument()
        {
            dt = obj.ViewAllDocument();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // Calling : api/document/viewdocumentbyid/{id}
        [HttpGet]
        [Route("viewdocumentbyid/{id}")]
        public HttpResponseMessage ViewDocumentById(int id)
        {
            dt = obj.ViewDocumentById(id);
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // Calling : api/document/savedocument
        [HttpPost]
        [Route("savedocument")]
        public HttpResponseMessage SaveDocument()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    //string FileName = obj.Save_Update_Delete_Document();
                    int DocId= obj.Save_Update_Delete_Document();
                    var message = Request.CreateResponse(HttpStatusCode.Created, DocId);
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please select file");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/document/updatedocument
        [HttpPut]
        [Route("updatedocument")]
        public HttpResponseMessage UpdateDocument()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (Convert.ToInt32(httpRequest.Form["DocumentId"]) > 0)
                {
                    //string FileName = obj.Save_Update_Delete_Document();
                    int DocId = obj.Save_Update_Delete_Document();
                    var message = Request.CreateResponse(HttpStatusCode.Created, DocId);
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please enter Document Id");
                }


            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // Calling : api/document/deletedocument
        [HttpDelete]
        [Route("deletedocument")]
        public HttpResponseMessage DeleteDocument()
        {
            try
            {
                //string FileName = obj.Save_Update_Delete_Document();
                int DocId = obj.Save_Update_Delete_Document();
                return Request.CreateResponse(HttpStatusCode.OK, DocId);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
