using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Employee
    {
        public string Name { get; set; }
        public List<string> Skills { get; set; }
    }

    class Program1
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            Employee emp1 = new Employee { Name = "Deepak", Skills = new List<string> { "C", "C++", "Java" } };
            Employee emp2 = new Employee { Name = "Karan", Skills = new List<string> { "SQL Server", "C#", "ASP.NET" } };

            Employee emp3 = new Employee { Name = "Lalit", Skills = new List<string> { "C#", "ASP.NET MVC", "Windows Azure", "SQL Server" } };

            employees.Add(emp1);
            employees.Add(emp2);
            employees.Add(emp3);

            // Query using Select()
            IEnumerable<List<String>> resultSelect = employees.Select(e => e.Skills);

            Console.WriteLine("**************** Select ******************");

            // Two foreach loops are required to iterate through the results
            // because the query returns a collection of arrays.
            foreach (List<String> skillList in resultSelect)
            {
                foreach (string skill in skillList)
                {
                    Console.WriteLine(skill);
                }
                Console.WriteLine();
            }

            // Query using SelectMany()
            IEnumerable<string> resultSelectMany = employees.SelectMany(emp => emp.Skills);

            Console.WriteLine("**************** SelectMany ******************");

            // Only one foreach loop is required to iterate through the results 
            // since query returns a one-dimensional collection.
            foreach (string skill in resultSelectMany)
            {
                Console.WriteLine(skill);
            }

            Console.ReadKey();
        }
    }

    //class Class2
    //{
    //}
    //public interface Name<T>
    //{
    //    T a { get; set; }
    //    //T b { get; set; }
    //}
    //public class MyGenericArray<T> : Name<T>
    //{
    //    private T[] array;

    //    public MyGenericArray(int size)
    //    {
    //        array = new T[size + 1];
    //    }

    //    private T A;
    //    public T a
    //    {
    //        get
    //        {
    //            return A;
    //        }

    //        set
    //        {
    //            A = value;
    //        }
    //    }

    //    public T getItem(int index)
    //    {
    //        return array[index];
    //    }
    //    public void setItem(int index, T value)
    //    {
    //        array[index] = value;
    //    }
    //}
    //class Tester
    //{
    //    static void Main(string[] args)
    //    {

    //        //declaring an int array
    //        MyGenericArray<int> intArray = new MyGenericArray<int>(5);

    //        intArray.a = 10;
    //        Console.WriteLine(intArray.a);

    //        //setting values
    //        for (int c = 0; c < 5; c++)
    //        {
    //            intArray.setItem(c, c * 5);
    //        }

    //        //retrieving the values
    //        for (int c = 0; c < 5; c++)
    //        {
    //            Console.Write(intArray.getItem(c) + " ");
    //        }

    //        Console.WriteLine();

    //        //declaring a character array
    //        MyGenericArray<char> charArray = new MyGenericArray<char>(5);
    //        charArray.a = 'A';
    //        Console.WriteLine(charArray.a);

    //        //setting values
    //        for (int c = 0; c < 5; c++)
    //        {
    //            charArray.setItem(c, (char)(c + 97));
    //        }

    //        //retrieving the values
    //        for (int c = 0; c < 5; c++)
    //        {
    //            Console.Write(charArray.getItem(c) + " ");
    //        }
    //        Console.WriteLine();

    //        Console.ReadKey();
    //    }
    //}
}
