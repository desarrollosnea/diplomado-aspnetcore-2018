using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Environment01.Models;
using Microsoft.AspNetCore.Hosting;

namespace Environment01.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _env { get; set; }

        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            ViewBag.Ambiente = _env.EnvironmentName;
            ViewBag.IsDevelopment = _env.IsDevelopment();
            ViewBag.IsStaging = _env.IsStaging();
            ViewBag.IsProduction = _env.IsProduction();

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
