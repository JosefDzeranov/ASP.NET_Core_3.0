using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductBase productBase;
        private readonly ICartBase cartBase;

        public CartController(IProductBase productBase, ICartBase cartBase)
        {
            this.productBase = productBase;
            this.cartBase = cartBase;

        }
        public IActionResult Index()
        {
            var cart = cartBase.TryGetByUserId(Const.UserId);

            return View(cart);
        }

        public IActionResult Add(int productId)
        {

            var product = productBase.TryGetById(productId);
            cartBase.Add(product, Const.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {

            var product = productBase.TryGetById(productId);
            cartBase.RemoveItem(product, Const.UserId);

            return RedirectToAction("Index");
        }
        public IActionResult RemoveAll()
        {

           
            cartBase.Clear(Const.UserId);

            return RedirectToAction("Index");
        }
    }
}
