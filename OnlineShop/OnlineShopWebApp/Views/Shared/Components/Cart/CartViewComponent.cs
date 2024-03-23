using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using System.Security.Claims;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsStorage cartsDbStorage;
        private readonly UserManager<User> userManager;

        public CartViewComponent(ICartsStorage cartsDbStorage, UserManager<User> userManager)
        {
            this.cartsDbStorage = cartsDbStorage;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            //var userId = HttpContext.Request.Cookies["tempUserId"];
            var userId = User.Identity.IsAuthenticated ? userManager.GetUserId(User as ClaimsPrincipal) : HttpContext.Request.Cookies["tempUserId"];
            var cart = cartsDbStorage.TryGetByUserId(userId);
            var cartViewModel = cart.ToCartViewModel();

            return View("Cart", cartViewModel);
        }
    }
}
