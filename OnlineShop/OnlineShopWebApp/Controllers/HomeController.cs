using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductBase _productBase;

        public HomeController(IProductBase productBase)
        {
            _productBase = productBase;
        }

        public IActionResult Index()
        {
            var products = _productBase.AllProducts();
            return View(products.ToProductViewModels());
        }

        public IActionResult SearchByName(string rawSearchName)
        {
            var searchName = String.Empty;

            if (!string.IsNullOrEmpty(rawSearchName))
            {
                searchName = rawSearchName.ToLower();
            }
            var Products = _productBase.AllProducts().Where(x => x.Name.ToLower().Contains(searchName));
            return View(Products.ToProductViewModels());
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
