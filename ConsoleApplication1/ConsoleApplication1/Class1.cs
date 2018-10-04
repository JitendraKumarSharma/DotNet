using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class x
    {
        private int a;
        public int b;
        protected int c;
        internal int d;
        protected internal int e;

        public void show()
        {
            a = 10;
            c = 50;
            Console.WriteLine(a);
        }
    }
    class y : x
    {
        //static void Main(string[] args)
        //{
        //    y obj = new y();
        //}
    }

    class BaseRun
    {
        //static void Main(string[] args)
        //{
        //    x obj = new x();
        //    y obj1 = new y();



        //}
    }
}

namespace ConsoleApplication22
{
    using ConsoleApplication1;
    class a : x
    {
        //static void Main(string[] args)
        //{
        //    a obj = new a();
        //    x obj2 = new x();
        //    //obj2.


        //}
    }

}