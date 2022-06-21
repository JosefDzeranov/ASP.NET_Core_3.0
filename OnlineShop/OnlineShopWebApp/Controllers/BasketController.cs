using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;

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
            var userId = HttpContext.Request.Cookies["userId"];
            var basket = _basketStorage.TryGetByUserId(userId);

            if (basket == null || basket.Items.Count == 0)
            {
                return View("Empty");
            }

            var basketViewModel = basket.ToBasketViewModel();

            return View(basketViewModel);
        }

        public IActionResult Add(Guid id)
        {
            var userId = HttpContext.Request.Cookies["userId"];
            var product = _productStorage.TryGetProduct(id);
            _basketStorage.Add(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var userId = HttpContext.Request.Cookies["userId"];
            var product = _productStorage.TryGetProduct(id);
            _basketStorage.Remove(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var userId = HttpContext.Request.Cookies["userId"];
            _basketStorage.Clear(userId);
            return RedirectToAction("Index");
        }
    }
}
