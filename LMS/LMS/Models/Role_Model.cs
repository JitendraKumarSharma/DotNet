using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LMS.Global;

namespace LMS.Models
{
    public class Role_Model
    {
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string Action { get; set; }
    }
}