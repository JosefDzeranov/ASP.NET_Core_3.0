using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using System;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Filters;

namespace OnlineShopWebApp.Controllers
{
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class CartController : Controller
    {
        private readonly IBuyerManager _buyerManager;
        private readonly IUserManager _userManager;
        private readonly IProductManager _productManager;
        public CartController(IBuyerManager buyerManager, IProductManager productManager, IUserManager userManager)
        {
            _buyerManager = buyerManager;
            _userManager = userManager;
            _productManager = productManager;
        }
        public IActionResult Index()
        {
            var buyer = _buyerManager.FindBuyer(_userManager.GetLoginAuthorizedUser());
            if (buyer == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(buyer);
        }

        public IActionResult AddProduct(Guid productId)
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            
            object routeValues = new { buyerLogin, Index = "Index", controller = "Cart", area = "" };

            if (_userManager.GettingAccess(buyerLogin, "Index", "Cart", ""))
            {
                var product = _productManager.Find(productId);
                _buyerManager.AddProductInCart(product, buyerLogin);
            }
            else
            {
                return RedirectToAction("TabooAccess", "Login", routeValues);
            }

            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult DeleteProduct(Guid productId)
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            _buyerManager.DeleteProductInCart(productId, buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult ReduceDuplicateProduct(Guid productId)
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            _buyerManager.ReduceDuplicateProductCart(productId, buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult Clear()
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            _buyerManager.ClearCart(buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }
    }


}
