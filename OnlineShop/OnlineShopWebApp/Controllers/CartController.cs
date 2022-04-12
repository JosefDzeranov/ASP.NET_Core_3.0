using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartsStorage cartsStorage;

        private readonly Constants constants;

        public ICartsStorage CartsStorage { get; }

        public IProductsStorage ProductsStorage { get; }

        public CartController(ICartsStorage cartsStorage, IProductsStorage productsStorage)
        {
            this.CartsStorage = cartsStorage;

            this.ProductsStorage = productsStorage;

            constants = new Constants();
        }
        
        public IActionResult Index()
        {
            var cart = cartsStorage.TryGetByUserId(constants.UserId);

            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = cartsStorage.TryGetProduct(productId);

            cartsStorage.Add(product, constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
