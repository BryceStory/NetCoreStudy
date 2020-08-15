using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using NetCoreStudy.Models;

namespace NetCoreStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IConfiguration _Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
           
            _logger = logger;
            _Configuration = configuration;
        }

        public class Test
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public IActionResult Index()
        {


            var a = _Configuration.GetSection("test").Get<Test>();
            Console.WriteLine("aaa"+a.Id.ToString());
            ChangeToken.OnChange(() => _Configuration.GetReloadToken(), () => { var b=_Configuration.GetSection("test").Get<Test>();Console.WriteLine($"bbb"+b.Id.ToString()); });
           
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
