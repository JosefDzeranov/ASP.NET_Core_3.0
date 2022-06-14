using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using System;
using OnlineShopWebApp.Filters;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class CartController : Controller
    {
        private readonly ICartsManager _cartsManager;
        private readonly IUsersManager _usersManager;
        public CartController(IUsersManager usersManager, ICartsManager cartsManager)
        {
            _usersManager = usersManager;
            _cartsManager = cartsManager;
        }
        public IActionResult Index()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var cart = _cartsManager.Find(buyerLogin);
            if (cart == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(cart);
        }

        public IActionResult AddProduct(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsManager.AddProductInCart(productId, buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult DeleteProduct(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsManager.DeleteProductInCart(productId, buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult ReduceDuplicateProduct(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsManager.ReduceDuplicateProductCart(productId, buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult Clear()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsManager.ClearCart(buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }
    }


}
