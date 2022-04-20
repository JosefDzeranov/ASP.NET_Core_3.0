using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartsStorage cartsStorage;

        private readonly IProductsStorage productsStorage;

        public CartController(IProductsStorage productsStorage, ICartsStorage cartsStorage)
        {
            this.cartsStorage = cartsStorage;

            this.productsStorage = productsStorage;
        }
        
        public IActionResult Index()
        {
            var cart = cartsStorage.TryGetByUserId(Constants.UserId);

            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsStorage.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsStorage.RemoveProduct(product, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCountProductCart(int productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsStorage.RemoveCountProductCart(product, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCartUser(string userId)
        {
            cartsStorage.RemoveCartUser(userId);

            return RedirectToAction("Index");
        }
    }
}
