using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public AdminController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
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
            var products = productsRepository.GetAllProducts();
            if (products == null || products.Count == 0)
                return View("notFound");
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            productsRepository.Add(product);
            return View();
        }

        public IActionResult Edit(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            productsRepository.Edit(product);
            return View();
        }

        public IActionResult Clear(int productId)
        {
            productsRepository.Clear(productId);
            return RedirectToAction("Index");
        }
    }
}
