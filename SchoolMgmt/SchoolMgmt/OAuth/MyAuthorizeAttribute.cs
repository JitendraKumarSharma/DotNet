using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SchoolMgmt.OAuth
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public MyAuthorizeAttribute(params string[] roles)
        {
            allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var identity = new ClaimsIdentity(httpContext.User.Identity);
                var claims = identity.Claims.ToList();
                var loggedUserRole = claims.Where(claim => claim.Type.ToLower().Contains("role"))
                                           .Select(claim => claim.Value).FirstOrDefault();
                if (allowedroles.Any() && allowedroles.Contains(loggedUserRole))
                {
                    authorize = true;
                }
                else if (allowedroles.Count().Equals(0))
                {
                    authorize = true;
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult(403);
        }
    }
}