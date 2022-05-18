using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
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
        public IActionResult Index(string buyerLogin)
        {
            var buyer = buyerManager.FindBuyer(buyerLogin);
            if (buyer == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {

            }
            return View();
        }

        public IActionResult AddProduct(Guid productId, string buyerLogin)
        {
            var product = productManager.Find(productId);
            var user = userManager.FindByLogin(buyerLogin);
            object routeValues = new { buyerLogin, Index = "Index", controller = "Cart", area = "" };
            if (user == null)
            {
                return RedirectToAction("Index", "Login", routeValues);
            }
            else
            {
                if (userManager.GettingAccess(buyerLogin, "Index", "Cart", ""))
                {
                    buyerManager.AddProductInCart(product, buyerLogin);
                }
                else
                {
                    return RedirectToAction("TabooAccess", "Login", routeValues);
                }

            }
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult DeleteProduct(Guid productId, string buyerLogin)
        {
            buyerManager.DeleteProductInCart(productId, buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult ReduceDuplicateProduct(Guid productId, string buyerLogin)
        {
            buyerManager.ReduceDuplicateProductCart(productId, buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }

        public IActionResult Clear(string buyerLogin)
        {
            buyerManager.ClearCart(buyerLogin);
            return RedirectToAction("Index", new { buyerLogin });
        }
    }


}
