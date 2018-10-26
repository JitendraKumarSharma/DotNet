using LMS.DAL;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.BAL
{
    public class Document_Bal
    {
        private Document_Dal obj;
        private Document_Model _doc;
        public Document_Bal(Document_Dal _obj, Document_Model _objdoc)
        {
            obj = _obj;
            _doc = _objdoc;
        }

        //public string Save_Update_Delete_Document()
        public int Save_Update_Delete_Document()
        {
            int id = 0;
            try
            {
                var httpRequest = HttpContext.Current.Request;

                _doc.DocumentId = Convert.ToInt32(httpRequest.Form["DocumentId"]);
                _doc.CreatedBy = Convert.ToInt32(httpRequest.Form["CreatedBy"]);
                _doc.Action = Convert.ToString(httpRequest.Form["Action"]);

                var fileName = string.Empty;
                if (httpRequest.Files.Count > 0)
                {
                    for (int i = 0; i < httpRequest.Files.Count; i++)
                    {
                        var postedFile = httpRequest.Files[i];

                        fileName = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + DateTime.Now.Millisecond + "_" + postedFile.FileName;
                        var filePath = HttpContext.Current.Server.MapPath("~/UploadedDocuments/" + fileName);

                        postedFile.SaveAs(filePath);

                        id = obj.Save_Update_Delete_Document(fileName, _doc);
                    }
                }
                else
                {
                    id = obj.Save_Update_Delete_Document(fileName, _doc);
                    fileName = id.ToString();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable ViewAllDocument()
        {
            return obj.ViewAllDocument();
        }

        public DataTable ViewDocumentById(int id)
        {
            return obj.ViewDocumentById(id);
        }
        public int DeleteDocument()
        {
            return obj.DeleteDocument();
        }
    }
}