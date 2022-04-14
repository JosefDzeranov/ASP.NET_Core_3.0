using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Purchase()
        {
            return View();
        }

    }
}
