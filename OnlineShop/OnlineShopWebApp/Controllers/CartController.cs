using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly CartsStorage cartsStorage;
        
        private readonly ProductsStorage productsStorage;

        private readonly Constants constants;

        public CartController(CartsStorage cartsStorage, ProductsStorage productsStorage)
        {
            this.cartsStorage = cartsStorage;

            this.productsStorage = productsStorage;
            
            constants = new Constants();
        }

        public IActionResult Index()
        {
            var cart = cartsStorage.TryGetByUserId(constants.UserId);

            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsStorage.Add(product, constants.UserId);
            return RedirectToAction("Index");
        }
    }
}