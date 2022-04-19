using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IBuyerStorage buyerCatalog;
        private readonly IProductStorage productCatalog;
        public CartController(IBuyerStorage buyerCatalog, IProductStorage productCatalog)
        {
            this.buyerCatalog = buyerCatalog;
            this.productCatalog = productCatalog;
        }
        public IActionResult Index(int personId)
        {
            return View(buyerCatalog.FindPerson(personId));
        }

        public IActionResult AddProductInCart(int productId, int personId)
        {
            buyerCatalog.AddProductInCart(productId, personId, productCatalog);
            buyerCatalog.WriteToStorage();
            return RedirectToAction("Index",personId);
        }
        public IActionResult DeleteProductInCart(int productId, int buyerId)
        {
            buyerCatalog.DeleteProductInCart(productId, buyerId);
            buyerCatalog.WriteToStorage();
            return RedirectToAction("Index", buyerId);
        }


    }
}
