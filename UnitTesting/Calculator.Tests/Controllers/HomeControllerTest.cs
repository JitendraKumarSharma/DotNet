using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;
using UnitTesting.Controllers;
using Moq;
using UnitTesting.Services;
using UnitTesting.Services.ServicesContract;
using Unity;
using Microsoft.Practices.Unity.Configuration;

namespace CalculatorTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private ICalculator calObj;
        private IUnityContainer unityContainer;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            unityContainer = new UnityContainer();
            unityContainer.LoadConfiguration();
        }
        [TestMethod]
        public void Add_Test()
        {
            ICalculator target = unityContainer.Resolve<Calculator>();
            var expected = 10;
            var actual = this.calObj.Add(4, 4);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
