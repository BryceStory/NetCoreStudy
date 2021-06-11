using log4net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private ILoggerFactory _Factory = null;

        public FirstController(ILoggerFactory factory, ILogger<FirstController> logger)
        {
            this._Factory = factory;
            this._logger = logger;
        }
        public IActionResult Index()
        {
            var currentUser = new CurrentUser()
            {
                Id = 12,
                Name = "Bryte",
                LoginTime = DateTime.Now
            };

            //this._logger.LogInformation("dasdadada");
            this._Factory.CreateLogger<FirstController>().LogError("_Factory---error");
            this._logger.LogError("_logger ---erroe");

            if (string.IsNullOrEmpty(this.HttpContext.Session.GetString("CurrentUserSession")))
            {
                base.HttpContext.Session.SetString("CurrentUserSession", Newtonsoft.Json.JsonConvert.SerializeObject(new CurrentUser()
                {
                    Id = 13,
                    Name = "BVryte",
                    LoginTime = DateTime.Now
                }));
            }

            return View(currentUser);
        }

        public IActionResult Grid()
        {
            return View();
        }
    }
}
