using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductReposititory productReposititory;

        public HomeController()
        {
            productReposititory = new ProductReposititory();
        }

        public IActionResult Index()
        {
            var products = productReposititory.GetAll();
            return View(products);
            /// <summary>
            /// Use them to pass only constants and small data.
            /// ViewBag.Product = result;
            /// ViewData["Products"] = result;
            /// TempData["Products"] = result;
            /// </summary>

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
