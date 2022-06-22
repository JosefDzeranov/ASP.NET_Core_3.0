using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartsStorage cartsDbStorage;

        private readonly IProductsStorage productsStorage;

        public CartController(IProductsStorage productsStorage, ICartsStorage cartsDbStorage)
        {
            this.cartsDbStorage = cartsDbStorage;

            this.productsStorage = productsStorage;
        }

        public IActionResult Index()
        {
            var cart = cartsDbStorage.TryGetByUserId(Constants.UserId);

            if (cart == null || cart.Items.Count == 0)
            {
                return View();
            }

            var cartViewModel = cart.ToCartViewModel();

            return View(cartViewModel);
        }

        public IActionResult Add(Guid productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsDbStorage.Add(product, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(Guid productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsDbStorage.RemoveProduct(product, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCountProductCart(Guid productId)
        {
            var product = productsStorage.TryGetProduct(productId);

            cartsDbStorage.RemoveCountProductCart(product, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cartsDbStorage.ClearCartUser(Constants.UserId);

            return RedirectToAction("Index");
        }
    }
}
