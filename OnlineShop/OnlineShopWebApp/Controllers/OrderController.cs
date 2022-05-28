using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

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
        public IActionResult Buy(DeliveryInformationViewModel deliveryInformation)
        {
            if (ModelState.IsValid)
            {
                var cart = cartsRepository.TryGetByUserId(Constants.UserId);
                ordersRepository.Add(cart.Items, Mapping.ToDbDelivery(deliveryInformation));
                cartsRepository.Clear(Constants.UserId);
                return View();
            }
            else
            {
                return View(deliveryInformation);
            }
        }
    }
}
