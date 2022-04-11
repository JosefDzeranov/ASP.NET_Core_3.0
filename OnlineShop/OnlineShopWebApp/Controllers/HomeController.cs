﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProductRepository productRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            productRepository = new ProductRepository();
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = productRepository.GetAllProducts();
            var result = "";

            foreach (var product in products)
            {
                result += product + "\n\n";
            }
            return View((object)result);
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
