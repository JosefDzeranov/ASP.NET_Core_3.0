using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private ICartManager cartManager;
        private readonly IProductManager productManager;

        public CartController(ICartManager cartManager, IProductManager productManager)
        {
            this.cartManager = cartManager;
            this.productManager = productManager;
        }

        public IActionResult Index()
        {
            var cart = cartManager.CreateCart();

            return View(cart);
        }


        public IActionResult AddToCart(Guid id)
        {
            var foundProduct = productManager.TryGetById(id);

            var productView = new ProductViewModel
            {
                Name = foundProduct.Name,
                Cost = foundProduct.Cost,
                Description = foundProduct.Description
            };

            cartManager.AddProductToCart(Constants.UserId, productView);
           
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(Guid id)
        {
            var foundProduct = productManager.TryGetById(id);
            var productView = new ProductViewModel
            {
                Name = foundProduct.Name,
                Cost = foundProduct.Cost,
                Description = foundProduct.Description
            };
            cartManager.RemoveProductFromCart(Constants.UserId, productView.Id);
         
            return RedirectToAction("Index");

        }

        public IActionResult ClearCart()
        {
            var cart = cartManager.TryGetCartByUserID(Constants.UserId);
            cartManager.RemoveCartLines(cart);
            return RedirectToAction("Index");

        }

    }

}
