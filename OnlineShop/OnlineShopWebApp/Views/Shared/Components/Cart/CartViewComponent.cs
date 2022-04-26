using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var existingUser = _userBase.AllUsers().First();
            var cart = _cartBase.TryGetByUserId(existingUser.Id);
            var productCounts = cart?.Amount ?? 0;
            return View("Cart",productCounts);
        }
    }
}
