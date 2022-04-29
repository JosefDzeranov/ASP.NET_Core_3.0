using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(User user)
        {
            if (ModelState.IsValid)
            {
                var enterData = usersRepository.TryGetByUserId(Constants.);
                var cart = cartsRepository.TryGetByUserId(Constants.UserId);
                ordersRepository.Add(enterData, cart, user);
                cartsRepository.Clear(Constants.UserId);
                return View();
            }
            else
            {
                return View(user);
            }
        }
    }
}
