using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutofacWebDemo.Models;
using AutofacWebDemo.Service;

namespace AutofacWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestService _testService;

        public HomeController(ILogger<HomeController> logger,ITestService iTestService)
        {
            _logger = logger;
            _testService = iTestService;
        }

        public IActionResult Index()
        {
            var a = _testService.Get();
            var b = _testService.GetName("hahah");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
