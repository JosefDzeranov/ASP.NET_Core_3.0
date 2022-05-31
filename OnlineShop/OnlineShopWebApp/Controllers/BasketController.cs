using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;
using System.Collections.Generic;
using OnlineShop.Db;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly IBasketStorage _basketStorage;

        public BasketController(IProductStorage productStorage, IBasketStorage basketStorage)
        {
            _productStorage = productStorage;
            _basketStorage = basketStorage;
        }
        public IActionResult Index()
        {
            var basket = _basketStorage.TryGetByUserId(Constants.UserId);

            if (basket == null || basket.Items.Count == 0)
            {
                return View("Empty");
            }

            var basketViewModel = basket.ToBasketViewModel();

            return View(basketViewModel);
        }

        public IActionResult Add(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            _basketStorage.Add(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            _basketStorage.Remove(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _basketStorage.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
