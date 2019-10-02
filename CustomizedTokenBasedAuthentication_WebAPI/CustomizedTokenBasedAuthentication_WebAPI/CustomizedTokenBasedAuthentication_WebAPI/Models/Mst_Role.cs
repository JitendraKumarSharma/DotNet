using System.Collections.Generic;

namespace CustomizedTokenBasedAuthentication_WebAPI.Models
{
    public class Mst_Role
    {
        public int roleId;
        public string roleName;
        public bool isActive;
        public string action;
        public List<Mst_Role> roleList;
        public Mst_Role()
        {
            roleId = 0;
            roleName = action = string.Empty;
            isActive = false;
            roleList = new List<Mst_Role>();
        }
    }
}