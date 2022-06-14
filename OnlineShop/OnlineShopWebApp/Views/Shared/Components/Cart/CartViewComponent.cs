using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsManager _cartsManager;
        private readonly IUsersManager usersManager;

        public CartViewComponent(ICartsManager cartsManager, IUsersManager usersManager)
        {
            _cartsManager = cartsManager;
            this.usersManager = usersManager;
        }

        public IViewComponentResult Invoke()
        {
            var buyerLogin = usersManager.GetLoginAuthorizedUser();
            var cart = _cartsManager.Find(buyerLogin);
            int sumProduct;
            if (cart == null)
            {
                sumProduct = 0;
            }
            else
            {
                sumProduct = _cartsManager.SumAllProducts(buyerLogin);
            }
            return View("Cart", sumProduct);
        }
        
    }
}
