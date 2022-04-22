using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

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

        public IActionResult AddProduct(int productId, int buyerId)
        {
            var product = productStorage.FindProduct(productId);
            buyerStorage.AddProductInCart(product, buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        public IActionResult DeleteProductInCart(int productId, int buyerId)
        {
            buyerStorage.DeleteProductInCart(productId, buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        public IActionResult ReduceDuplicateProductCart(int productId, int buyerId)
        {
            buyerStorage.ReduceDuplicateProductCart(productId, buyerId);
            return RedirectToAction("Index", new { buyerId });
        }

        public IActionResult CleenCart(int buyerId)
        {
            buyerStorage.CleenCart(buyerId);
            return RedirectToAction("Index", new { buyerId });
        }
    }
}
