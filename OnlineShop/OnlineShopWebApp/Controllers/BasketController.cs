using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly OrderReposititory orderReposititory;

        public BasketController()
        {
            orderReposititory = new OrderReposititory();
        }

        public IActionResult Order(int id)
        {
            var order = orderReposititory.TryGetById(id);
            return View(order);

        }

    }
}
