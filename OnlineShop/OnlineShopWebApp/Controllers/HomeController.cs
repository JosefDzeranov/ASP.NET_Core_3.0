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

        private readonly ProdcutBase prodcutBase;

        public HomeController()
        {
            prodcutBase = new ProdcutBase();
        }
        public IActionResult Index()
        {
            var products = prodcutBase.GetAll();
            
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
