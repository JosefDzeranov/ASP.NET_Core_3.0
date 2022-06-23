using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using System.Security.Claims;

namespace OnlineShopWebApp.Views.Components.Basket
{
    public class BasketViewComponent: ViewComponent
    {
        private readonly IBasketStorage _basketStorage;
        private readonly UserManager<User> _userManager;

        public BasketViewComponent(IBasketStorage basketStorage, UserManager<User> userManager)
        {
            _basketStorage = basketStorage;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userId = User.Identity.IsAuthenticated ? _userManager.GetUserId(User as ClaimsPrincipal) : HttpContext.Request.Cookies["tempUserId"];
            var basket = _basketStorage.TryGetByUserId(userId);
            var basketViewModel = basket.ToBasketViewModel();
            return View("Basket", basketViewModel);
        }
    }
}
