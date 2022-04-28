using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductBase _productBase;

        public AdminController(IProductBase productBase)
        {
            _productBase = productBase;
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
            var products = _productBase.AllProducts();
            return View(products);
        }

        public IActionResult AddNewProduct()
        {
            return View();
        }

        public IActionResult EditProduct(int productId)
        {
            var product = _productBase.TryGetById(productId);
            return View(product);
        }

        public IActionResult DeleteProduct(int productId)
        {
            _productBase.Delete(productId);
            return RedirectToAction("products", "admin");
        }
    }
}
