using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;

namespace CustomizedTokenBasedAuthentication_WebAPI.OAuth
{
    public class MyAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        //protected override bool IsAuthorized(HttpActionContext actionContext)
        //{
        //    IPrincipal incomingPrincipal = actionContext.RequestContext.Principal;
        //    //Debug.WriteLine(string.Format("Principal is authenticated at the start of IsAuthorized in CustomAuthorizationFilterAttribute: {0}", incomingPrincipal.Identity.IsAuthenticated));
        //    return false;
        //}

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var identity = new ClaimsIdentity(actionContext.RequestContext.Principal.Identity);
                var claims = identity.Claims.ToList();
                var loggedUserRole = claims.Where(claim => claim.Type.ToLower().Contains("role"))
                                           .Select(claim => claim.Value).FirstOrDefault();
                var allowedRoles = Roles;
                if (!string.IsNullOrEmpty(allowedRoles) && !allowedRoles.Contains(loggedUserRole))
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                }
            }
            else
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
        }
    }
}