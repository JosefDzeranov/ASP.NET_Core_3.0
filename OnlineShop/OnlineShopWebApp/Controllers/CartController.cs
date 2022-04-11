using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductBase prodcutBase;
        private readonly ICartBase cartBase;

        public CartController(IProductBase productBase, ICartBase cartBase)
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
