using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helper;
using OnlineShopWebApp.Models;

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

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", order);
            }

            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
            var existingCartViewModel = Mapping.ToCartViewModel(existingCart);

            order.Items = existingCartViewModel.Items;

            odersRepository.Create(order);
            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
