using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void AddNewOrder(DeliveryInfo deliveryInfo)
        {
            var existingUser = _userBase.AllUsers().First();
            var cart = _cartBase.TryGetByUserId(existingUser.Id);
            var order = new Order(cart, deliveryInfo);
            _orderBase.Add(order);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(DeliveryInfo deliveryInfo)
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
