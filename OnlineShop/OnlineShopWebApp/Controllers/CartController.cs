using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
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
        public IActionResult AddProduct(int product, int buyerId)
        {
            buyerStorage.AddProductInCart(product, buyerId);
            return RedirectToAction("Index", new {buyerId});
        }
        public IActionResult DeleteProduct(int productId, int buyerId)
        {
            buyerStorage.DeleteProductInCart(productId, buyerId);
            return RedirectToAction("Index", new { buyerId });
        }
        public IActionResult ReduceDuplicateProduct(int productId, int buyerId)
        {
            buyerStorage.ReduceDuplicateProductCart(productId, buyerId);
            return RedirectToAction("Index", new { buyerId });
        }
        public IActionResult Clear(int buyerId)
        {
            buyerStorage.ClearCart(buyerId);
            return RedirectToAction("Index", new { buyerId });
        }
    }


}
