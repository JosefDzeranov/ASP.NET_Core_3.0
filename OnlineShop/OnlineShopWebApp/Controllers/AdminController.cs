using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductStorage _productStorage;
        public AdminController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {
            var products = _productStorage.GetProductData();
            return View(products);
        }

        public IActionResult Add(int id)
        {
            return View();
        }
        
        public IActionResult Edit(int id)
        {
            return View();

        }public IActionResult Remove(int id)
        {
            return View();
        }
    }
}
