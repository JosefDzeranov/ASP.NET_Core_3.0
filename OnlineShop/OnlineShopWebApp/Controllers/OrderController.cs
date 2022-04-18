using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepozitory cartsRepozitory;
        private readonly IOrdersRepozitory ordersRepozitory;

        public OrderController(ICartsRepozitory cartsRepozitory, IOrdersRepozitory ordersRepozitory)
        {
            this.cartsRepozitory = cartsRepozitory;
            this.ordersRepozitory = ordersRepozitory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buy()
        {
            var cart = cartsRepozitory.TryGetByUserId(Constants.UserId);
            ordersRepozitory.Add(cart);
            cartsRepozitory.Clear(Constants.UserId);
            return View();
        }
    }
}
