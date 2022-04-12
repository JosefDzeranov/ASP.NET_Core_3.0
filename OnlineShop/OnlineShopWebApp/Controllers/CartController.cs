using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartsStorage cartsStorage;

        private readonly IProductsStorage productsStorage;

        private readonly Constants constants;

        public CartController(IProductsStorage productsStorage, ICartsStorage cartsStorage)
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

        public IActionResult RemoveProduct(int productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsStorage.RemoveProduct(product, constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCountProductCart(int productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsStorage.RemoveCountProductCart(product, constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveAll()
        {
            cartsStorage.RemoveAll();

            return RedirectToAction("Index");
        }
    }
}
