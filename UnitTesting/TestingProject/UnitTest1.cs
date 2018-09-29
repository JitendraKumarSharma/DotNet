using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Microsoft.Practices.Unity.Configuration;
using UnitTesting.Services.ServicesContract;
using UnitTesting.Services;
using Moq;

namespace TestingProject
{
    [TestClass]
    public class UnitTest1
    {
        private IUnityContainer unityContainer;
        private ICalculator calObj;
        [TestInitialize()]
        public void MyTestInitialize()
        {
            unityContainer = new UnityContainer();
            calObj = unityContainer.Resolve<Calculator>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Mock<checkEmployee> chk = new Mock<checkEmployee>();
            chk.Setup(x => x.checkEmp()).Returns(true);

            var obj = chk.Object;
            processEmployee obje = new processEmployee();
            Assert.AreEqual(obje.insertEmployee(obj), true);

            //Mock<Calculator> chk1 = new Mock<Calculator>();
            //chk1.Setup(x => x.Largest(5)).Returns(true);
            //var obj1 = chk1.Object;
            Calculator obje1 = new Calculator();
            //Assert.AreEqual(obje1.Multiply(obj1), 5);

            var exp = calObj.Multiply(obje1);
            Assert.AreEqual(exp, 4);

            var expected = 10;
            var actual = calObj.Add(5, 5);
            Assert.AreEqual(expected, actual);
        }
    }

    public class checkEmployee
    {
        public virtual Boolean checkEmp()
        {
            throw new NotImplementedException();
        }
    }

    public class processEmployee
    {
        public Boolean insertEmployee(checkEmployee objtmp)
        {
            objtmp.checkEmp();
            return true;
        }
    }
}
