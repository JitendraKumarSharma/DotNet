using SchoolMgmt.OAuth;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace SchoolMgmt.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("data/forall")]
        public ActionResult Get()
        {
            ViewBag.msg = "Now server tiime is : " + DateTime.Now.ToString();
            return View();
        }

        [MyAuthorize]
        [HttpGet]
        [Route("data/authenticate")]
        public ActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            ViewBag.msg = "Hello " + identity.Name;
            return View();
        }

        //[MyAuthorize(Roles = "admin")]
        [MyAuthorize("admin")]
        [HttpGet]
        [Route("data/authorize")]
        public ActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(claim => claim.Type == ClaimTypes.Role)
                                       .Select(claim => claim.Value);
            ViewBag.msg = "Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList());
            return View();
        }
    }
}