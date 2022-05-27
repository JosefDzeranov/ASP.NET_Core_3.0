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
        private readonly IBuyerManager buyerManager;
        private readonly IProductManager productManager;
        private readonly IUserManager userManager;
        public CartController(IBuyerManager buyerManager, IProductManager productManager, IUserManager userManager)
        {
            this.buyerManager = buyerManager;
            this.productManager = productManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var buyer = buyerManager.FindBuyer(userManager.GetLoginAuthorizedUser());
            if (buyer == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(buyer);
        }

        public IActionResult AddProduct(Guid productId)
        {
            var buyerLogin = userManager.GetLoginAuthorizedUser();
            
            object routeValues = new { buyerLogin, Index = "Index", controller = "Cart", area = "" };

            if (userManager.GettingAccess(buyerLogin, "Index", "Cart", ""))
            {
                buyerManager.AddProductInCart(productId, buyerLogin);
            }
            else
            {
                return RedirectToAction("TabooAccess", "Login", routeValues);
            }

            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult DeleteProduct(Guid productId)
        {
            var buyerLogin = userManager.GetLoginAuthorizedUser();
            buyerManager.DeleteProductInCart(productId, buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult ReduceDuplicateProduct(Guid productId)
        {
            var buyerLogin = userManager.GetLoginAuthorizedUser();
            buyerManager.ReduceDuplicateProductCart(productId, buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult Clear()
        {
            var buyerLogin = userManager.GetLoginAuthorizedUser();
            buyerManager.ClearCart(buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }
    }


}
