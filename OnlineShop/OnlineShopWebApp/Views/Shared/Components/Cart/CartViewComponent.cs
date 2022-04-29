using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {

            var cart = cartsRepository.TryGetByUserId(Constants.UserId);
            var productCounts = cart?.Amout ?? 0;

            if (productCounts == 0)
                return View("Empty", string.Empty);
            return View("cart", productCounts);
        }
    }
}
