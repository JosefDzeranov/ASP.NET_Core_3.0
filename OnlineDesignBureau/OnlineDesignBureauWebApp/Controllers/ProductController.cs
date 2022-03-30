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
    public class ProductController : Controller
    {

        public string Index()
        {
            return "тест 1";
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
