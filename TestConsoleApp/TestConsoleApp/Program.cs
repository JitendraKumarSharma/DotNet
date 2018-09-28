using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    interface i1
    {
        void showInterface();
    }
    public abstract class A : i1
    {
        int cnt = 1;
        public abstract int add(int x, int y);
        public virtual void display()
        {
            cnt++;
            Console.WriteLine("From A " + cnt);
        }

        public abstract void showInterface();
        //{
        //    Console.WriteLine("Interface from Abstract A");
        //}

    }

    public class B : A
    {
        const int sum = 0;
        static int sum1 = 0;
        readonly int sum2 = 0;
        static B()
        {
            //sum2 = 4;
            sum1 = 55;
        }

        public B()
        {

        }
        private B(int a,int b)
        {

        }

        private B(int c)
        {

        }
        int sum3 = 12;

        //sum1=55; //gives error

        public void abc()
        {
            Console.WriteLine(sum);
        }

        public override int add(int x, int y)
        {
            //sum = x + y; //gives error
            //sum2 = x + y;//gives error
            sum1 = x + y;
            return sum1;
        }

        public override void showInterface()
        {
            Console.WriteLine("Interface from Abstract A");
        }

    }

    class C : B
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            Console.WriteLine(b.add(5, 6));
            b.display();
            b.showInterface();
            Console.ReadLine();
        }
    }

}
