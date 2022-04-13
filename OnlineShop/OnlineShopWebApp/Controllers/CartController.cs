using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public CartController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }
        public IActionResult Index()
        {
            var cart = CartsStorage.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = productsStorage.TryGetProduct(productId);
            CartsStorage.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
