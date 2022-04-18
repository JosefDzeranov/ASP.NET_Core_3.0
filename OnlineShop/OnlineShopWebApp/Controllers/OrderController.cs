using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartRepository, IOrdersRepository ordersRepository)
        {
            this.cartRepository = cartRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buy()
        {
            var existingCart = cartRepository.TryGetByUserId(Constants.UserId);
            ordersRepository.Add(existingCart);
            cartRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
