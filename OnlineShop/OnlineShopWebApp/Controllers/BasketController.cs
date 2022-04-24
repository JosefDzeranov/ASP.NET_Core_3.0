using System;
using Microsoft.AspNetCore.Mvc;

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

            return View(basket);
        }

        public IActionResult Add(string productId)
        {
            var product = _productStorage.TryGetProduct(productId);
            _basketStorage.AddProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string productId)
        {
            var product = _productStorage.TryGetProduct(productId);
            _basketStorage.RemoveProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _basketStorage.ClearBasket(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
