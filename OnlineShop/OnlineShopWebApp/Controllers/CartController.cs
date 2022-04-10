using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsStorage productStorage;
        public CartController()
        {
            productStorage = new ProductsStorage();
        }

        public IActionResult Index()
        {
            var cart = CartsStorage.TryGetByUserId(Constants.UserId);

            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = ProductsStorage.TryGetProduct(productId);

            CartsStorage.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
