using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductBase _productBase;
        private readonly ICartBase _cartBase;
        private readonly IUserBase _userBase;


        public IActionResult Index()
        {
            var existingUser = _userBase.AllUsers().First();
            var cart = _cartBase.TryGetByUserId(existingUser.Id);
            return View(cart.ToCartViewModel());
        }

        public CartController(IProductBase productBase, ICartBase cartBase, IUserBase userBase)
        {
            _productBase = productBase;
            _cartBase = cartBase;
            _userBase = userBase;
        }

        public IActionResult Add(int productId)
        {
            var existingUser  = _userBase.AllUsers().First();
            var product = _productBase.AllProducts().FirstOrDefault(x => x.Id == productId);
            _cartBase.Add(product, existingUser.Id);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(int productId)
        {
            var existingUser = _userBase.AllUsers().First();
            _cartBase.DecreaseAmount(productId, existingUser.Id);
            return RedirectToAction("Index");
        }
    }
}
