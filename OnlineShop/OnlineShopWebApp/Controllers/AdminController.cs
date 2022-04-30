﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsStorage productsStorage;
        public AdminController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Customers()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            var products = productsStorage.GetAll();
            return View(products);
        }

        public IActionResult Edit(int productId)
        {
            var product = productsStorage.TryGetProduct(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult SaveEditedProduct(Product product)
        {
            productsStorage.SaveEditedProduct(product);
            return View();
        }

        public IActionResult Delete(int productId)
        {
            productsStorage.Delete(productId);

            return RedirectToAction("Products");
        }
    }
}