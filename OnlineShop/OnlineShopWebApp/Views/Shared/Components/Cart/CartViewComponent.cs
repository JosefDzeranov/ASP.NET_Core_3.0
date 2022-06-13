using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartBase _cartBase;
        private readonly UserManager<User> _userManager;


        public CartViewComponent(ICartBase cartBase, UserManager<User> userManager)
        {
            _cartBase = cartBase;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            if(userName == null)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.UserName.Contains("user"));
                var cart = _cartBase.TryGetByUserId(user.Id);
                var ProductViewModelCounts = cart.ToCartViewModel()?.Amount ?? 0;
                return View("Cart", ProductViewModelCounts);
            }
            else
            {
                var cart = _cartBase.TryGetByUserName(userName);
                var ProductViewModelCounts = cart.ToCartViewModel()?.Amount ?? 0;
                return View("Cart", ProductViewModelCounts);
            }
        }
    }
}
