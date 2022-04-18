using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductDataSource productDataSource;
        private readonly ICartRepository cartRepository;

        public HomeController(IProductDataSource productDataSource, ICartRepository cartRepository)
        {
            this.productDataSource = productDataSource;
            this.cartRepository = cartRepository;
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

        public IActionResult Index()
        {

            var products = productDataSource.GetAllProducts();

            return View(products);
        }
    }
}
