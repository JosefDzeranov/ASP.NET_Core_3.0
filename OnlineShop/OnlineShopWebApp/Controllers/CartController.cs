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
        public IActionResult Index(int personId)
        {
            return View(buyerStorage.FindBuyer(personId));
        }
        public IActionResult AddProductInCart(int productId, int buyerId, IProductStorage productStorage)
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
