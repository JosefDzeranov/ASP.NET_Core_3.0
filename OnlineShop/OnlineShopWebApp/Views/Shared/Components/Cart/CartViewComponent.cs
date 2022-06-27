using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IUsersManager usersManager;

        public CartViewComponent(ICartsRepository cartsRepository, IUsersManager usersManager)
        {
            _cartsRepository = cartsRepository;
            this.usersManager = usersManager;
        }

        public IViewComponentResult Invoke()
        {
            var buyerLogin = usersManager.GetLoginAuthorizedUser();
            var cart = _cartsRepository.Find(buyerLogin);
            int sumProduct;
            if (cart == null)
            {
                sumProduct = 0;
            }
            else
            {
                sumProduct = _cartsRepository.QuantityAllProducts(buyerLogin);
            }
            return View("Cart", sumProduct);
        }
        
    }
}
