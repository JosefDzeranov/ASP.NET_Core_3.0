using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
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
        public IActionResult Buy(UserDeliveryInfo user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }

            var existingCart = cartsRepository.TryGetByUserId(Constants.UserId);
            
            var order = new Order
            {
                User = user,
                Items= existingCart.Items
            };

            odersRepository.Add(order);
            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
