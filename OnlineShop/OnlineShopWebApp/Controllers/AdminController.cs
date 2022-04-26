using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productStorage.AddProduct(product);
            return RedirectToAction("Products");
        }
        
        public IActionResult Edit(string id)
        {
            var product = _productStorage.TryGetProduct(id);
            return View(product);
        }
        
        [HttpPost]
        public IActionResult Save(Product product)
        {
            _productStorage.EditProduct(product);
            return RedirectToAction("Products");
        }
 
        public IActionResult Remove(string id)
        {
            _productStorage.RemoveProduct(id);
            return RedirectToAction("Products"); ;
        }
    }
}
