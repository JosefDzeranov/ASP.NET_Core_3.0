using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsStorage cartsDbStorage;

        public CartViewComponent(ICartsStorage cartsDbStorage)
        {
            this.cartsDbStorage = cartsDbStorage;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsDbStorage.TryGetByUserId(Constants.UserId);

            var cartViewModel = cart.ToCartViewModel();
            return View("Cart", cartViewModel);
        }
    }
}
