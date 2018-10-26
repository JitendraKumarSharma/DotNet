using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Document_Model
    {
        public int DocumentId { get; set; }
        public string DocumentPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string Action { get; set; }
    }
}