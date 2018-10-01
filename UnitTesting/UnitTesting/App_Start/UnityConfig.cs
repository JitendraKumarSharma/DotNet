using System.Web.Mvc;
using UnitTesting.Controllers;
using UnitTesting.Services;
using UnitTesting.Services.ServicesContract;
using Unity;
using Unity.Mvc5;

namespace UnitTesting
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICalculator, Calculator>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}