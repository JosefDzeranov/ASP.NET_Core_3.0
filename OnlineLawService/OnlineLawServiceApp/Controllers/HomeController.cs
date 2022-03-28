using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineLawServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLawServiceApp.Controllers
{
    public class StartController : Controller
    {
        public string Hello()
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 6)
                return "Доброе утро";
            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 12)
                return "Добрый день";
            if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
                return "Добрый вечер";
            if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour < 24)
                return "Доброй ночи";
            else
                return "";
        }
        
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        


        //public IActionResult Index(string name, int age)
        //{
        //    return View();
        //}

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
