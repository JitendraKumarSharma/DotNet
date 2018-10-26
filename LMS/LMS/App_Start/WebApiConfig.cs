using LMS.BAL;
using LMS.DAL;
using LMS.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;

namespace LMS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new LMS.ExceptionHandle.LMSExceptionHandler());

            // Web API configuration and services
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new System.Net.Http.Formatting.QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            //container.RegisterSingleton<Role_Bal>();
            //container.RegisterSingleton<RegistrationType_Bal>();
            //container.RegisterSingleton<Registration_Bal>();
            //container.RegisterSingleton<Login_Bal>();
            //container.RegisterSingleton<Document_Bal>();
            //container.RegisterSingleton<Activity_Bal>();
            //container.RegisterSingleton<MsgRequestType_Bal>();
            //container.RegisterSingleton<FQuestion_Bal>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
