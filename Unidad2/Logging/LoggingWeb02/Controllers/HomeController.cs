using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoggingWeb02.Models;
using Microsoft.Extensions.Logging;

namespace LoggingWeb02.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("[Curso] Information > Diplomado ASP.NET Core 1.0 ");

            _logger.LogWarning("[Curso] Warning > Diplomado ASP.NET Core 1.0 ");

            _logger.LogCritical("[Curso] Critical > Diplomado ASP.NET Core 1.0 ");


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
