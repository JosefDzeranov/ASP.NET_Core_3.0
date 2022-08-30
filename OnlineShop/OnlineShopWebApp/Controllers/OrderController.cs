using AutoMapper;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BL;
using System.Linq;
using ViewModels;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderServicies _orderServicies;
        private readonly ICartServicies _cartServicies;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrderServicies orderServicies, ICartServicies cartServicies, UserManager<User> userManager, IMapper mapper)
        {
            _orderServicies = orderServicies;
            _cartServicies = cartServicies;
            _userManager = userManager;
            _mapper = mapper;
        }

        private void AddNewOrder(DeliveryInfoModelView deliveryInfo)
        {
            var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var cart = _cartServicies.TryGetByUserId(existingUser.Id);
            var order = new Order(cart.Items, _mapper.Map<DeliveryInfo>(deliveryInfo));

            _orderServicies.Add(order);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(DeliveryInfoModelView deliveryInfo)
        {
            if (ModelState.IsValid)
            {
                AddNewOrder(deliveryInfo);
                var existingUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                _cartServicies.Delete(existingUser.Id);
                return View();
            }
            else
            {
                return View("Index");
            }
        }

    }
}
