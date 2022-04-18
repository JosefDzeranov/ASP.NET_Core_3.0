using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using System;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Views;


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
            int? productCount = cartRepository.Amount;

            if (productCount == 0)
                productCount = null;

            return View("Cart", productCount);

        }
    }
}
