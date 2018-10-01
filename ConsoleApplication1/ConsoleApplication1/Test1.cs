using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Test1
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 50; x++)
                {
                    Console.Write("Hi ");
                }
            });
            t.Wait();
            Console.WriteLine();
        }
    }
}
