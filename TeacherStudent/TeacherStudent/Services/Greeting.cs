using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeacherStudent.ServiceContract;

namespace TeacherStudent.Services
{
    public class Greeting : IGreeting
    {
        public string getGreeting()
        {
            return "Hello " + GetHashCode();
        }
    }
}