using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using System;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class CartController : Controller
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IUsersManager _usersManager;
        public CartController(IUsersManager usersManager, ICartsRepository cartsRepository)
        {
            _usersManager = usersManager;
            _cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var cart = _cartsRepository.Find(buyerLogin);
            if (cart == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var cartVM = Mapping.ToCart_ViewModel(cart);
            return View(cartVM);
        }

        public IActionResult AddProduct(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsRepository.AddProduct(productId, buyerLogin);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsRepository.DeleteProductInCart(productId, buyerLogin);
            return RedirectToAction("Index");
        }

        public IActionResult ReduceDuplicateProduct(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsRepository.ReduceDuplicateProductCart(productId, buyerLogin);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _cartsRepository.ClearCart(buyerLogin);
            return RedirectToAction("Index");
        }
    }


}
