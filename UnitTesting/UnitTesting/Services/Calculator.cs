using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTesting.Services.ServicesContract;

namespace UnitTesting.Services
{
    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }

        public void Largest(int a)
        {
            //throw new NotImplementedException();
            var tt= a > 5;
        }
        private int Val;
        public int val
        {
            get
            {
                return 2;
            }
            set
            {
                Val = value;
            }
        }

        public int Multiply(Calculator a)
        {
            a.Largest(4);
            var dd = a.val * 2;
            return dd;
        }
    }
}