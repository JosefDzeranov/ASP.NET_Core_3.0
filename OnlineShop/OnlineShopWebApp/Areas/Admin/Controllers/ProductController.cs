using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductBase _productBase;


        public ProductController(IProductBase productBase)
        {
            _productBase = productBase;
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

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productBase.Add(product);
                return RedirectToAction("Products", "Product");
            }
            else
            {
                return View("AddNewProduct");
            }

        }

        [HttpGet]
        public IActionResult EditProduct(int productId)
        {
            var product = _productBase.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productBase.Edit(product);
                return RedirectToAction("products", "product");
            }
            else
            {
                return View("EditProduct", product);
            }

        }

        public IActionResult DeleteProduct(int productId)
        {
            _productBase.Delete(productId);
            return RedirectToAction("Products", "Product");
        }

    }
}
