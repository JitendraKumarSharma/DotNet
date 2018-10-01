using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Services.ServicesContract
{
    public interface ICalculator
    {
        int val
        {
            get;
            set;
        }
        int Add(int a, int b);
        int Sub(int a, int b);
        void Largest(int a);

        int Multiply(Calculator a);
    }
}
