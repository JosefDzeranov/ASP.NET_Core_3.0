using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly OnlineShop.Db.ICartsRepository cartsRepository;
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
        public IActionResult Buy(DeliveryInformarion deliveryInformarion)
        {
            if (ModelState.IsValid)
            {
                var cart = cartsRepository.TryGetByUserId(Constants.UserId);
                ordersRepository.Add(Mapping.ToCartViewModel(cart), deliveryInformarion);
                cartsRepository.Clear(Constants.UserId);
                return View();
            }
            else
            {
                return View(deliveryInformarion);
            }
        }
    }
}
