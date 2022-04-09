﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsReposititory productRepository;

        public CartController()
        {
            productRepository = new ProductsReposititory();
        }

        public IActionResult Index(int prodictId)
        {
            var cart = CartRepository.TryGetByUserId(Constants.UserId);
            return View(cart);

        }
        public IActionResult Add(int prodictId)
        {
            var product = productRepository.TryGetById(prodictId);
            CartRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");

        }

    }
}
