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
    public class OrderController : Controller
    {
        private readonly IOrderBase _orderBase;
        private readonly ICartBase _cartBase;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrderBase orderStorage, ICartBase cartBase, UserManager<User> userManager)
        {
            _orderBase = orderStorage;
            _cartBase = cartBase;
            _userManager = userManager;
        }

        private void AddNewOrder(DeliveryInfoModelView deliveryInfo)
        {
            var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var cart = _cartBase.TryGetByUserId(existingUser.Id).ToCartViewModel();
            var order = new Order(cart.Items.Select(x => x.ToCartItem()).ToList(), deliveryInfo.ToDeliveryInfo());
            _orderBase.Add(order);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(DeliveryInfoModelView deliveryInfo)
        {
            if (ModelState.IsValid)
            {
                AddNewOrder(deliveryInfo);
                var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                _cartBase.Delete(existingUser.Id);
                return View();
            }
            else
            {
                return View("Index");
            }
        }

    }
}
