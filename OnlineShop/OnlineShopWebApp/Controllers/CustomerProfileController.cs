using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class CustomerProfileController : Controller
    {
        private readonly UserDbRepository userDbRepository;

        public CustomerProfileController(UserDbRepository userDbRepository)
        {
            this.userDbRepository = userDbRepository;
        }
        public IActionResult Index()
        {
            var currentUser = userDbRepository.TryGetByName(User.Identity.Name);
            var userViewModel = currentUser.ToUserViewModel();
            //get current user, convert to UserViewModel and send it to the view
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Create(UserViewModel customer)
        {
            var currentUser = userDbRepository.TryGetByName(User.Identity.Name);
            currentUser.Update(customer);
            userDbRepository.UpdateUser();

            var order = new OrderViewModel();
            //order.Name = customer.Name;
            //order.Phone = customer.Phone;
            //order.Email = customer.Email;
            //order.Address = customer.Adress;

            return RedirectToAction("Buy", "OrderComplete", order);
        }
    }
}
