using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Data;
using LMS.DAL;
using LMS.Global;

namespace LMS.OAuth
{
    public class LMSAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        Login_Dal obj;
        DataTable dt;
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            obj = new Login_Dal();
            dt = obj.GetLoginDetail(context.UserName, context.Password);
            if (dt.Rows.Count > 0)
            {
                #region User Details Who Logged In
                SessionInfo.UserId = Convert.ToInt32(dt.Rows[0]["userid"]);
                SessionInfo.UserName = Convert.ToString(dt.Rows[0]["username"]);
                SessionInfo.RoleId = Convert.ToInt32(dt.Rows[0]["roleid"]);
                SessionInfo.Role = Convert.ToString(dt.Rows[0]["role"]);
                SessionInfo.RegistrationTypeId = Convert.ToInt32(dt.Rows[0]["registrationtype"]);
                SessionInfo.RegistrationType = Convert.ToString(dt.Rows[0]["regtype"]);
                SessionInfo.EmailId = Convert.ToString(dt.Rows[0]["emailid"]);
                SessionInfo.ContactNo = Convert.ToString(dt.Rows[0]["contactno"]);
                SessionInfo.Address = Convert.ToString(dt.Rows[0]["address"]);
                SessionInfo.CreatedBy = Convert.ToInt32(dt.Rows[0]["createdby"]);
                SessionInfo.DatabaseId = Convert.ToInt32(dt.Rows[0]["DatabaseId"]);
                #endregion

                //identity.AddClaim(new Claim(ClaimTypes.Role, Convert.ToString(dt.Rows[0]["role"])));
                //identity.AddClaim(new Claim("username", Convert.ToString(dt.Rows[0]["username"])));
                //identity.AddClaim(new Claim(ClaimTypes.Name, Convert.ToString(dt.Rows[0]["username"])));
                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {"userId", Convert.ToString(dt.Rows[0]["userid"])},
                    {"userName", Convert.ToString(dt.Rows[0]["username"])},
                    {"emailId", Convert.ToString(dt.Rows[0]["emailid"])},
                    {"roleId", Convert.ToString(dt.Rows[0]["roleid"])},
                    {"role", Convert.ToString(dt.Rows[0]["role"])},
                    {"registrationType", Convert.ToString(dt.Rows[0]["registrationtype"])},
                    {"databaseId", Convert.ToString(dt.Rows[0]["DatabaseId"])}
                 });
                //AuthenticationProperties properties = CreateProperties(context.UserName);
                AuthenticationTicket ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username or password is incorrect");
            }

            //if (context.UserName == "admin" && context.Password == "admin")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            //    identity.AddClaim(new Claim("username", "admin"));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "Rahul Sharma"));
            //    AuthenticationProperties properties = CreateProperties(context.UserName);
            //    AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);
            //    context.Validated(ticket);

            //}
            //else if (context.UserName == "user" && context.Password == "user")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            //    identity.AddClaim(new Claim("username", "user"));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, "Arun Sharma"));
            //    AuthenticationProperties properties = CreateProperties(context.UserName);
            //    AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);
            //    context.Validated(ticket);
            //}
            //else
            //{
            //    context.SetError("invalid_grant", "Provided username and password is incorrect");
            //    return;
            //}
        }

        //public static AuthenticationProperties CreateProperties(string userName)
        //{
        //    IDictionary<string, string> data = new Dictionary<string, string>
        //    {
        //        {    "userName", userName }
        //    };
        //    return new AuthenticationProperties(data);
        //}

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}