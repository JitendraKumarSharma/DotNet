using DependencyDemo.Controllers;
using DependencyDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DependencyDemo.Custom
{
    public class MyControllerFactory : System.Web.Mvc.DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            IGreetingService igs = GreetingService.GetInstance;
            
            //GreetingController grt = new GreetingController(igs);
            //return grt;

            Type typeCont = Type.GetType(string.Format("DependencyDemo.Controllers.{0}Controller", controllerName));
            return Activator.CreateInstance(typeCont, new[] { igs }) as System.Web.Mvc.IController;
            //return base.CreateController(requestContext, controllerName);
        }
    }
}