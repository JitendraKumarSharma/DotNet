using LMS.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LMS.Models
{
    public class Registration_Model
    {
        //#region Property Declaration
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public int DatabaseId { get; set; }
        public string Password { get; set; }
        public int RegistrationType { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string Action { get; set; }
        public string Salt { get; set; }
        //#endregion
    }
}