using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;

        }
        public IActionResult Index()
        {

            var products = productRepository.GetAll();

            return View(products);
        }


        public IActionResult DeleteProduct(int id)
        {
            var product = productRepository.TryGetById(id);
            if (product != null)
            {
                productRepository.Delete(product);
            }
            return RedirectToAction("Index", "Product");
        }

        public IActionResult EditProduct(int id)
        {
            var product = productRepository.TryGetById(id);

            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product changingProduct)
        {
            if (ModelState.IsValid)
            {
                productRepository.Update(changingProduct);
            }

            return RedirectToAction("Index", "Product");
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productRepository.Add(product);
            return RedirectToAction("Index", "Product");
        }

    }
}
