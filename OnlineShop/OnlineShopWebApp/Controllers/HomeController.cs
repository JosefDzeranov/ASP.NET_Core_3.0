using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepozitory productRepozitory;

        public HomeController()
        {
            productRepozitory = new ProductRepozitory();
        }

        public IActionResult Index()
        {
            var products = productRepozitory.GetAll();
           
            return View(products);
        }

        public IActionResult Basket()
        {
            var products = productRepozitory.GetAll();

            return View(products);
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
