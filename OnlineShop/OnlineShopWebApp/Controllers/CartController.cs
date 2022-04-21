using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IBuyerStorage buyerStorage;
        private readonly IProductStorage productStorage;
        public CartController(IBuyerStorage buyerStorage, IProductStorage productStorage)
        {
            this.buyerStorage = buyerStorage;
            this.productStorage = productStorage;
        }
        public IActionResult Index(int buyerId)
        {
            return View(buyerStorage.FindBuyer(buyerId));
        }
        public IActionResult AddProductInCart(int productId, int buyerId)
        {
            buyerStorage.AddProductInCart(productId, buyerId, productStorage);
            return RedirectToAction("Index", buyerId);
        }
        public IActionResult DeleteProductInCart(int productId, int buyerId)
        {
            buyerStorage.DeleteProductInCart(productId, buyerId);
            return RedirectToAction("Index", buyerId);
        }
        public IActionResult ReduceDuplicateProductCart(int productId, int buyerId)
        {
            buyerStorage.ReduceDuplicateProductCart(productId, buyerId);
            return RedirectToAction("Index", buyerId);
        }
        public IActionResult CleenCart(int buyerId)
        {
            buyerStorage.CleenCart(buyerId);
            return RedirectToAction("Index", buyerId);
        }
    }


}
