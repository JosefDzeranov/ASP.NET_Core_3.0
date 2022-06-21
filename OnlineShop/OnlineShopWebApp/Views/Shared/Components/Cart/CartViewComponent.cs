using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using OnlineShop.db.Models;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartRepository cartRepository;
        private readonly UserManager<User> userManager;

        public CartViewComponent(ICartRepository cartRepository, UserManager<User> userManager)
        {
            this.cartRepository = cartRepository;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartRepository.TryGetByUserId(User.Identity.Name);
            int? productCount = cart?.Items.Sum(x => x.Amount) ?? 0;

            if (productCount == 0)
                productCount = null;

            return View("Cart", productCount);
        }
  
    }
}


