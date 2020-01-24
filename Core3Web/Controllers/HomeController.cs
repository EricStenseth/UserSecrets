using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core3Web.Models;
using Microsoft.Extensions.Configuration;

namespace Core3Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // get secret value, should be different from appsettings
            // right click project -> Manage User Secrets
            /* secrets.json should look like
             *{
             *  "MySecret": "very secret"
             *}
             */
            var secret =_configuration["MySecret"];
            if(secret == "not secret")
                throw new Exception("Could not find correct secret value");

            return View("Index", secret);
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
