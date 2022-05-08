using Microsoft.AspNetCore.Mvc;
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
            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
            odersRepository.AddCart(existingCart);
            odersRepository.SaveOrderInformation(order);
            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
