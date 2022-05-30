using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Models;

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
            var cartDb = cartRepository.TryGetByUserId(Const.UserId);
            if(cartDb != null)
            {
                var cartViewModel = cartDb.MappingCartViewModel();
                var productCount = cartViewModel?.Count ?? 0;
                return View("Cart", productCount);
            }

            return View("Cart", 0);
        }
    }
}
