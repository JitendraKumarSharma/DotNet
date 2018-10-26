using LMS.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Login_Model
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int RegistrationTypeId { get; set; }
        public string RegistrationType { get; set; }
        public int CreatedBy { get; set; }
    }
}