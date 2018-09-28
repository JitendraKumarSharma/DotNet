using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyDemo.Services
{
    public class GreetingService : IGreetingService
    {
        private static int counter = 0;
        private static readonly Lazy<GreetingService> instance = new Lazy<GreetingService>(() => new GreetingService());
         public static GreetingService GetInstance
        {
            get
            {
                //if (instance == null)
                //{
                //    lock (obj)
                //    {
                //        if (instance == null)
                //        {
                //            instance = new Singleton();
                //        }
                //    }
                //}

                return instance.Value;
            }
        }

        private GreetingService()
        {
            counter++;
            Console.WriteLine("Counter Value = " + counter);

        }

        private string msg;
        public string MSG
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
            }
        }
        public string GetGreeting()
        {
            return "hello" + GetHashCode();
        }
    }
}