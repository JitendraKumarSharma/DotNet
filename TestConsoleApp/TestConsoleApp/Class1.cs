using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class CC
    {

    }
    abstract class Class1 : CC
    {
        public virtual void show()
        {
            Console.Write("hello");
        }
    }

    abstract class AA : Class1
    {
        public override void show()
        {
            base.show();
        }
    }

    public abstract class abc
    {
        public abstract void show();
    }

}
