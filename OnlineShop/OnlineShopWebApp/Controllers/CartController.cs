using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProdcutBase prodcutBase;
        private readonly Cart cart;
        public CartController()
        {
            prodcutBase = new ProdcutBase();
            cart = new Cart();
        }
        public IActionResult Index(int id)
        {
            if (id != 0)
            {
                var product = prodcutBase.TryGetById(id);
                cart.AddToCart(product);
            }

            return View(cart.TryGetAll());
        }
    }
}
