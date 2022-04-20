using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
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


    }


}
