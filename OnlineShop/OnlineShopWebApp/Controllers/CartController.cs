using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IBuyerStorage buyerStorage;
        public CartController(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }
        public IActionResult Index(int personId)
        {
            return View(buyerStorage.FindBuyer(personId));
        }
        public IActionResult AddProductInCart(int productId, int personId)
        {
            buyerStorage.AddProductInCart(productId, personId);
            return RedirectToAction("Index",personId);
        }
        public IActionResult DeleteProductInCart(int productId, int buyerId)
        {
            buyerStorage.DeleteProductInCart(productId, buyerId);
            return RedirectToAction("Index", buyerId);
        }


    }
}
