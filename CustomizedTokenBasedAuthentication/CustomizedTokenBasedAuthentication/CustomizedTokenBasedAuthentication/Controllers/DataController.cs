using CustomizedTokenBasedAuthentication.OAuth;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace CustomizedTokenBasedAuthentication.Controllers
{
    public class DataController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now server tiime is : " + DateTime.Now.ToString());
        }

        [MyAuthorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }


        [MyAuthorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(claim => claim.Type == ClaimTypes.Role)
                                       .Select(claim => claim.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }
    }
}
