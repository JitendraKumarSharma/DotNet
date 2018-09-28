using DependencyDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DependencyDemo.Controllers
{
    public class TestController : Controller
    {
        private IGreetingService _greetingService;
        public TestController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }
        // GET: Test
        public ActionResult Index()
        {
            ViewData["msg"] = _greetingService.GetGreeting();
            return View();
        }

        public void ChangeValue()
        {
            _greetingService.MSG = "hi";
            ViewData["msg"] = "Bye";
        }
    }
}