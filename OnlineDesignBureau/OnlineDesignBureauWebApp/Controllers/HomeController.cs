using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineDesignBureauWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        /*
         * параметры запроса обычно указываются через Qery параметр, 
         * для этого после сегментов ставится ? и пишется запрос возвращать можно не только IActionResult, 
         * но и любой другой тип переменной, если возвращать string то окно браузера будет играть роль консоли
         */
        public IActionResult Index(string name, int age)

        {
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
