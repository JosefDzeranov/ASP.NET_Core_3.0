using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IBuyerManager _buyerManager;
        private readonly IUserManager _userManager;

        public CartViewComponent(IBuyerManager buyerManager, IUserManager userManager)
        {
            _buyerManager = buyerManager;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = _buyerManager.FindBuyer(_userManager.GetLoginAuthorizedUser());
            int sumProduct;
            if (user == null)
            {
                sumProduct = 0;
            }
            else
            {
                sumProduct = user.SumAllProducts();
            }
            return View("Cart", sumProduct);
        }
        
    }
}
