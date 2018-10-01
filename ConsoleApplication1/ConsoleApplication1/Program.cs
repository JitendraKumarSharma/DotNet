using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Collections;

namespace ConsoleApplication1
{
    public static class IntExtensions
    {
        public static bool IsGreaterThan(this int i, int value,int b)
        {
            return i > value;
        }
    }

    class first
    {
        public int number { get; set; }
        public second age { get; set; }
    }

    class second
    {
        public int no1 { get; set; }
        public int no2 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Mark";
            var date = DateTime.Now;

            // Composite formatting:
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
            Console.WriteLine(String.Format("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date));
            // String interpolation:
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
            var aa = new first
            {
                number = 1234
            };
            Console.WriteLine(aa.age?.no1 ?? 10001); //new code  

            const int ww = 20;
            Console.WriteLine($"{Math.PI,ww} - default formatting of the pi number");
            Console.WriteLine($"{Math.PI,ww:F3} - display only three decimal digits of the pi number");

            //string name = "Horace";
            //int age = 34;
            //Console.WriteLine($"He asked, \"Is your name {name}?\", but didn't wait for a reply :-{{");
            //Console.WriteLine($"{name} is {age} year{(age == 1 ? "" : "s")} old.");
            Hashtable ht = new Hashtable();
            ht.Add(1, "One");
            ht.Add(2, "Two");
            ht.Add(3, "Three");
            ht.Add(4, "Four");
            ht.Add("Fv", "Five");
            ht.Add(8.5F, 8.5);

            foreach (var key in ht.Keys)
                Console.WriteLine("Key:{0}, Value:{1}", key, ht[key]);

            Console.WriteLine("***All Values***");

            foreach (var value in ht.Values)
                Console.WriteLine("Value:{0}", value);

            Func<int, int, int> hypotenuse = (a, b) => Convert.ToInt32(Math.Sqrt(a * a + b * b));
            var res = hypotenuse(3, 4);
            Console.WriteLine(res);
            Expression<Func<int, int, int>> addTwoNumbersExpression = (x, y) => x + y;
            BinaryExpression body = (BinaryExpression)addTwoNumbersExpression.Body;
            ParameterExpression left = (ParameterExpression)body.Left;
            ParameterExpression right = (ParameterExpression)body.Right;
            Console.WriteLine(body);
            dynamic dynamicVariable = 100;
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = "Hello World!!";
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = true;
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = DateTime.Now;
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());


            int i = 10;

            bool result = i.IsGreaterThan(100,3);

            Console.WriteLine("Result: {0}", result);


            //string name = "sandeep";
            //string myName = name;
            //string mm = "66";
            //Console.WriteLine("== operator result is {0}", name == myName);
            //Console.WriteLine("== operator result is {0}", name == mm);
            //Console.WriteLine("Equals method result is {0}", name.Equals(myName));
            //Console.WriteLine("Equals method result is {0}", name.Equals(mm));
            //Console.ReadKey();
            //Program m = new Program();
            //m.Main1();

        }

        public static string GetNextName(out int id)
        {
            id = 10;
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }
        void Main1()
        {
            int i = 10;
            Console.WriteLine("Previous value of integer i:" + i.ToString());
            string test = GetNextName(out i);
            Console.WriteLine("Current value of integer i:" + i.ToString());
            Console.ReadKey();
        }
    }

    //public static class test
    //{
    //    static int a = 10;
    //    static readonly int b = 10;

    //    // void show() gies error
    //    //{
    //    //}

    //    static test()
    //    {
    //        a = 400;
    //        //this.a = 400;
    //        b = 10;
    //    }
    //    static void show()
    //    {
    //        this.a = 440;
    //        b = 10;
    //    }
    //}

    //public class test1
    //{
    //    static int a = 10;
    //    readonly int b = 100;

    //    test1()
    //    {
    //        a = 100;
    //        b = 1000;
    //    }
    //    static test1()
    //    {
    //        a = 100;
    //        //b = 1000; gives error
    //    }

    //    void change()
    //    {
    //        a = 200;
    //        //b = 200; gives error
    //    }
    //}


}
