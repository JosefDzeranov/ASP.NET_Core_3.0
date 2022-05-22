using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;


namespace OnlineShopWebApp.Views.Components.Basket
{
    public class BasketViewComponent: ViewComponent
    {
        private readonly IBasketStorage _basketStorage;

        public BasketViewComponent(IBasketStorage basketStorage)
        {
            _basketStorage = basketStorage;
        }

        public IViewComponentResult Invoke()
        {
            var basket = _basketStorage.TryGetByUserId(Constants.UserId);
            var basketViewModel = basket.ToBasket
            return View("Basket", basketViewModel);
        }
    }
}
