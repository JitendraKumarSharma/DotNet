using BAL;
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

            //RegisterInstance return same instances each time IGreeting Calls
            container.RegisterInstance<IGreeting>(new Greeting());

            ////RegisterInstance return same instances each time IGreeting Calls
            //container.RegisterSingleton<IGreeting, Greeting>();

            ////RegisterType return different instances each time IGreeting Calls
            //container.RegisterType<IGreeting, Greeting>();



            container.RegisterType<SchoolContext>();
            container.RegisterType<Student_BAL>();

            //container.RegisterType<IEmail, Email>();
            //OR
            //when any component to access IEmail will get the object of Email
            container.RegisterInstance<IEmail>(new Email());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}