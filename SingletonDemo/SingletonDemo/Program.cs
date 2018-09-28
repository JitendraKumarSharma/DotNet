using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => Employee(),
                () => Student()
                );
            Console.ReadLine();
        }

        private static void Student()
        {
            Singleton fromStu = Singleton.GetInstance;
            fromStu.print("From Student");
        }

        private static void Employee()
        {
            Singleton fromEmp = Singleton.GetInstance;
            fromEmp.print("From Employee");
        }
    }
}
