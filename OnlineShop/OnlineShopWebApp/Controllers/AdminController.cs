using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsStorage productsStorage;
        public AdminController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Customers()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = productsStorage.GetAll();
            return View(products);
        }
    }
}