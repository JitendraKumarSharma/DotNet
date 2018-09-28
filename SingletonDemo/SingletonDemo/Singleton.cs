using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class Singleton
    {
        private static int counter = 0;
        //private static readonly object obj = new object();
        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());
        public static Singleton GetInstance
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
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value = " + counter);

        }
        public void print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
