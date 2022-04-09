using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProdcutBase prodcutBase;

        public CartController()
        {
            prodcutBase = new ProdcutBase();

        }
        public IActionResult Index()
        {
            var cart = CartBase.TryGetByUserId(Const.UserId);

            return View(cart);
        }

        public IActionResult Add(int productId)
        {

            var product = prodcutBase.TryGetById(productId);
            CartBase.Add(product, Const.UserId);

            return RedirectToAction("Index");
        }
    }
}
