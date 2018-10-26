using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class FQuestion_Model
    {
        public int FQuestionId { get; set; }
        public string FQuestion { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string Action { get; set; }
    }
}