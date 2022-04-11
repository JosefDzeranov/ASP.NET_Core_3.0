using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductBase prodcutBase;
        private readonly CartBase cartBase;

        public CartController(ProductBase productBase, CartBase cartBase)
        {
            this.prodcutBase = productBase;
            this.cartBase = cartBase;

        }
        public IActionResult Index()
        {
            var cart = cartBase.TryGetByUserId(Const.UserId);

            return View(cart);
        }

        public IActionResult Add(int productId)
        {

            var product = prodcutBase.TryGetById(productId);
            cartBase.Add(product, Const.UserId);

            return RedirectToAction("Index");
        }
    }
}
