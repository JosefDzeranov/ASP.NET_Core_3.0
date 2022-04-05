using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

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
            var product = prodcutBase.TryGetById(id);
            cart.AddToCart(product);
            return View(cart.TryGetAll());
        }
    }
}
