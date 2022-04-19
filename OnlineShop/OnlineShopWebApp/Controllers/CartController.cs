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
            return View(buyerStorage.FindPerson(personId));
        }

        public IActionResult AddProductInCart(int productId, int personId)
        {
            buyerStorage.AddProductInCart(productId, personId, productStorage);
            buyerStorage.WriteToStorage();
            return RedirectToAction("Index",personId);
        }
        public IActionResult DeleteProductInCart(int productId, int buyerId)
        {
            buyerStorage.DeleteProductInCart(productId, buyerId);
            buyerStorage.WriteToStorage();
            return RedirectToAction("Index", buyerId);
        }


    }
}
