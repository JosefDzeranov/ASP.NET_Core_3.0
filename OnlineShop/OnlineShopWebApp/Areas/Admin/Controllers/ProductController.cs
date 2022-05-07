using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductDataSource productDataSource;

        public ProductController(IProductDataSource productDataSource)
        {
            this.productDataSource = productDataSource;
        }

        public IActionResult Index()
        {
            return View(productDataSource.GetAllProducts());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                productDataSource.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        public IActionResult Remove(int productId)
        {
            productDataSource.RemoveProduct(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var product = productDataSource.GetProductById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productDataSource.EditProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

    }
}
