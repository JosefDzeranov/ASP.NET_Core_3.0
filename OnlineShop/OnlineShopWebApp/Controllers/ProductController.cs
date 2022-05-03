﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBase _productBase;

        public ProductController(IProductBase productBase)
        {
            _productBase = productBase;
        }

        public IActionResult Index(int id)
        {
            var products = _productBase.AllProducts().FirstOrDefault(p => p.Id == id);
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
