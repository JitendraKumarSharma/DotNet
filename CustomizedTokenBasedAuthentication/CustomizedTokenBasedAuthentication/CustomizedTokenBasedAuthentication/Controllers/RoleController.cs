using CustomizedTokenBasedAuthentication.OAuth;
using System.Collections.Generic;
using System.Web.Mvc;
using CustomizedTokenBasedAuthentication.Models;
using System.Data;
using CustomizedTokenBasedAuthentication.DAL;

namespace CustomizedTokenBasedAuthentication.Controllers
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