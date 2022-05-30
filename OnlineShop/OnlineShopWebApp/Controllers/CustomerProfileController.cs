using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class CustomerProfileController : Controller
    {
        private readonly ICustomerProfile customerProfile;

        public CustomerProfileController(ICustomerProfile customerProfile)
        {
            this.customerProfile = customerProfile;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var order = new OrderViewModel();
                order.Name = customer.Name;
                order.Phone = customer.Phone;
                order.Email = customer.Email;
                order.Address = customer.Adress;

                return RedirectToAction("Buy", "OrderComplete", order);
            }

            return View(customer);
        }
    }
}
