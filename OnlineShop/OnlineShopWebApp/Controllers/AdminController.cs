using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductDataSource productDataSource;

        public AdminController(IProductDataSource productDataSource)
        {
            this.productDataSource = productDataSource;
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
            return View(productDataSource.GetAllProducts());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productDataSource.AddProduct(product);
                return RedirectToAction("Products");
            }

            return View(product);
        }

        public IActionResult RemoveProduct(int productId)
        {
            productDataSource.RemoveProduct(productId);
            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult EditProduct(int productId)
        {
            var product = productDataSource.GetProductById(productId);
            return View(product);
        }

        [HttpPost]

        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productDataSource.EditProduct(product);
                return RedirectToAction("Products");
            }
            return View(product);
        }
    }
}
