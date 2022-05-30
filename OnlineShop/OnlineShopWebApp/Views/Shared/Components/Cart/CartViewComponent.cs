using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using System.Collections.Generic;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartRepository cartRepository;

        public CartViewComponent(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartRepository.TryGetByUserId(Const.UserId);
            int? productCount = cart?.Items.Sum(x=>x.Amount) ?? 0;

            if (productCount == 0)
                productCount = null;

            return View("Cart", productCount);
        }
    }
}
