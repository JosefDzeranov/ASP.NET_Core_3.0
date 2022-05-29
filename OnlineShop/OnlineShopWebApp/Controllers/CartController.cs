using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
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
            var cart = cartManager.TryGetCartByUserID(Constants.UserId);

            CartViewModel cartViewModel = Mapping.ToCartViewModel(cart);

            return View(cartViewModel);
        }


        public IActionResult AddToCart(Guid id)
        {
            var foundProduct = productManager.TryGetById(id);

          

            cartManager.AddProductToCart(Constants.UserId, foundProduct);
           
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
            cartManager.RemoveProductFromCart(Constants.UserId, foundProduct.Id);
         
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
