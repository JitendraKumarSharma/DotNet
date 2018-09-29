using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitTesting.Services.ServicesContract;

namespace UnitTesting.Controllers
{
    public class CalculatorController : Controller
    {
        private ICalculator calObj;
        public CalculatorController(ICalculator calObj)
        {
            this.calObj = calObj;
        }
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        public void Add()
        {
            this.calObj.Add(4, 4);
        }

        public void Sub()
        {
            this.calObj.Add(4, 4);
        }
    }
}