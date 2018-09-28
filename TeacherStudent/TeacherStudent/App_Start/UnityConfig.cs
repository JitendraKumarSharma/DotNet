using System.Web.Mvc;
using TeacherStudent.ModelClasses;
using TeacherStudent.ServiceContract;
using TeacherStudent.Services;
using Unity;
using Unity.Mvc5;

namespace TeacherStudent
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            IUnityContainer container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmail, Email>();
            container.RegisterType<SchoolContext>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}