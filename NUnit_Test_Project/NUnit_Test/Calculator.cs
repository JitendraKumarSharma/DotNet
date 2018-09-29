using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit_Test
{
    [TestFixture]
    public class Calculator
    {
        [SetUp]
        [Test]
        public void Add()
        {
            int a = 10;
            int b = 5;
            var result = a + b;
            Assert.AreEqual(15, result);
        }
        [Test]
        public void Sub()
        {
            int a = 10;
            int b = 5;
            var result = a - b;
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Mul()
        {
            int a = 10;
            int b = 5;
            var result = a * b;
            Assert.AreEqual(50, result);
        }

        [TearDown]
        [Test]
        public void Divide()
        {
            int a = 10;
            int b = 5;
            var result = a / b;
            Assert.AreEqual(2, result);
        }
    }
}
