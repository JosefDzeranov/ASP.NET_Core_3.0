using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

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

            var basketItemViewModels = new List<BasketItemViewModel>();
            foreach(var item in basket.Items)
            {
                var basketItemViewModel = new BasketItemViewModel
                {
                    Id = item.Id,
                    Product = item.Product,
                    Quantity = item.Quantity
                };
                basketItemViewModels.Add(basketItemViewModel);
            }

            var basketViewModel = new BasketViewModel
            {
                Id = basket.Id,
                UserId = basket.UserId,
                Items = basketItemViewModels
            };

            return View(basketViewModel);
        }

        public IActionResult Add(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            _basketStorage.AddProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
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
