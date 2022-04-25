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
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
              return Content($"{customer.Name}-{customer.Surname}-{customer.Email}-{customer.Phone}-{customer.Adress}");
            }

            return View(customer);
        }
    }
}
