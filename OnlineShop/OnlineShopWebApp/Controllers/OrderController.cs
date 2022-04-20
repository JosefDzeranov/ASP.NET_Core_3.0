using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartBase _cartBase;


        public OrderController(ICartBase cartsStorage)
        {
            _cartBase = cartsStorage;
        }

        public IActionResult Congratulation()
        {
            return View();
        }
        public IActionResult Buy()
        {
            _cartBase.Delete(TestUser.UserId);
            return View();
        }

    }
}
