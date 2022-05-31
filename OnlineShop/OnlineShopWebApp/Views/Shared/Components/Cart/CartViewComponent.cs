using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartBase _cartBase;
        private readonly IUserBase _userBase;


        public CartViewComponent(ICartBase cartBase, IUserBase userBase)
        {
            _cartBase = cartBase;
            _userBase = userBase;
        }

        public IViewComponentResult Invoke()
        {
            var existingUser = _userBase.AllUsers().FirstOrDefault();
            var cart = _cartBase.TryGetByUserId(existingUser.Id);
            var ProductViewModelCounts = cart.ToCartViewModel()?.Amount ?? 0;
            return View("Cart",ProductViewModelCounts);
        }
    }
}
