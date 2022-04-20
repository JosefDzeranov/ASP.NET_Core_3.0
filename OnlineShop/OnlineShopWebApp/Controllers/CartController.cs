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
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int itemId)
        {
            var product = productsRepository.TryGetById(itemId);
            cartsRepository.Delete(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cartsRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
