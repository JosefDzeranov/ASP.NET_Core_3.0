using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

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
            var productCount = cart.Count;
            return View("Cart",productCount);
        }
    }
}
