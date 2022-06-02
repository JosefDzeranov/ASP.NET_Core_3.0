using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Helpers;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderBase _orderBase;
        private readonly ICartBase _cartBase;
        private readonly IUserBase _userBase;

        public OrderController(IOrderBase orderStorage, ICartBase cartBase, IUserBase userBase)
        {
            _orderBase = orderStorage;
            _cartBase = cartBase;
            _userBase = userBase;
        }

        private void AddNewOrder(DeliveryInfoModelView deliveryInfo)
        {
            var existingUser = _userBase.AllUsers().First();
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

                var existingUser = _userBase.AllUsers().First();
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
