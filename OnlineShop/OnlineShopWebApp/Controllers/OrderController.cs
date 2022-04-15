using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
    
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository odersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository odersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.odersRepository = odersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
            public IActionResult Buy()
        {
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
            odersRepository.Add(existingCart);
            cartsRepository.Clear(Constants.UserId);
            return View();

        }
    }
}
