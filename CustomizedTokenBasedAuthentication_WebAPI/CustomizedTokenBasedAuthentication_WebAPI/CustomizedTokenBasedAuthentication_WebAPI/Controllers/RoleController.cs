using CustomizedTokenBasedAuthentication_WebAPI.OAuth;
using System.Collections.Generic;
using System.Web.Mvc;
using CustomizedTokenBasedAuthentication_WebAPI.Models;
using System.Data;
using CustomizedTokenBasedAuthentication_WebAPI.DAL;

namespace CustomizedTokenBasedAuthentication_WebAPI.Controllers
{
    public class RoleController : Controller
    {
        private Role objRole;
        DataTable dt;
        [MyAuthorize(Roles = "user")]
        public ActionResult GetRole(int id = 0)
        {
            IEnumerable<Mst_Role> roleList = objRole.GetAllRole();
            ViewData["roleList"] = roleList;
            return View();
        }

        [HttpPost]
        public ActionResult SaveRole(FormCollection fc)
        {
            return View();
        }
    }
}