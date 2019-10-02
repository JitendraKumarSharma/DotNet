using System;

namespace CustomizedTokenBasedAuthentication_WebAPI.Models
{
    public class Mst_User
    {
        public int userId;
        public string userName;
        public int roleId;
        public string email;
        public string password;
        public string salt;
        public DateTime createdBy;
        public Mst_User()
        {
            userId = roleId = 0;
            userName = email = password = salt = string.Empty;
            createdBy = new DateTime(1900, 01, 01);
        }
    }
}