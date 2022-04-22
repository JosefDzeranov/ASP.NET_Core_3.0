﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage productStorage;
        public HomeController( IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        public IActionResult Index()
        {
            return View(productStorage.Products);
        }
    }
}
