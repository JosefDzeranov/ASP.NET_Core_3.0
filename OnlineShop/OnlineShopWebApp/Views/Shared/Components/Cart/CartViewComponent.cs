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

        public CartViewComponent(ICartBase cartBase)
        {
            _cartBase = cartBase;
        }

        public IViewComponentResult Invoke()
        {
            var cart = _cartBase.TryGetByUserId(TestUser.UserId);
            var productCounts = cart?.Amount ?? 0;
            return View("Cart",productCounts);
        }
    }
}
