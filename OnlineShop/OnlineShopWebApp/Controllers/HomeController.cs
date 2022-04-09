﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsReposititory productReposititory;

        public HomeController()
        {
            productReposititory = new ProductsReposititory();
        }

        public IActionResult Products()
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
