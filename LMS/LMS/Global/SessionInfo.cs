using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Global
{
    public static class SessionInfo
    {
        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static int RoleId { get; set; }
        public static string Role { get; set; }
        public static string EmailId { get; set; }
        public static string ContactNo { get; set; }
        public static string Address { get; set; }
        public static int RegistrationTypeId { get; set; }
        public static string RegistrationType { get; set; }
        public static int DatabaseId { get; set; }
        public static int CreatedBy { get; set; }


    }
}