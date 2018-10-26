using LMS.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class RegistrationType_Model
    {
        public int RegTypeId { get; set; }
        public string RegType { get; set; }
        public string Action { get; set; }
    }
}