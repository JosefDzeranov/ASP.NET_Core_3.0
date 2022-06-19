using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;

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
            
            var cartViewModel = cart.ToCartViewModel();

            return View(cartViewModel);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsStorage.Add(product, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(Guid productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsStorage.RemoveProduct(product, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCountProductCart(Guid productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsStorage.RemoveCountProductCart(product, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCartUser()
        {
            cartsStorage.RemoveCartUser(Constants.UserId);

            return RedirectToAction("Index");
        }
    }
}
