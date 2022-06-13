using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductBase _productBase;
        private readonly ICartBase _cartBase;
        private readonly UserManager<User> _userManager;

        public CartController(IProductBase productBase, ICartBase cartBase, UserManager<User> userManager)
        {
            _productBase = productBase;
            _cartBase = cartBase;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var cart = _cartBase.TryGetByUserId(existingUser.Id);
            return View(cart.ToCartViewModel());
        }


        public IActionResult Add(int productId)
        {
            var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var product = _productBase.AllProducts().FirstOrDefault(x => x.Id == productId);
            _cartBase.Add(product, existingUser.Id);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(int productId)
        {
            var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            _cartBase.DecreaseAmount(productId, existingUser.Id);
            return RedirectToAction("Index");
        }
    }
}
