using DependencyDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DependencyDemo.Controllers
{
    public sealed class GreetingController : Controller
    {
        //private GreetingService _greetingService;
        private IGreetingService _greetingService;

        public GreetingController(IGreetingService greetingService)
        {
            //_greetingService = new GreetingService();
            _greetingService = greetingService;
        }
        // GET: Greeting
        public ActionResult Index()
        {
            ViewData["val"] = _greetingService.MSG;
            ViewData["msg"] = _greetingService.GetGreeting();
            return View();
        }
    }
}