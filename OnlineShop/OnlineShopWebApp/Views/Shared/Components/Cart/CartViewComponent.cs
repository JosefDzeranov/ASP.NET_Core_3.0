using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Models;
using System.Threading.Tasks;

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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
                var cartDb = await cartRepository.TryGetByUserIdAsync(userId);
                if (cartDb != null)
                {
                    var cartViewModel = cartDb.MappingToCartViewModel();
                    var productCount = cartViewModel?.Count ?? 0;
                    return View("Cart", productCount);
                }
                return View("Cart", 0);
            }
            

            return View("Cart", 0);
        }
    }
}
