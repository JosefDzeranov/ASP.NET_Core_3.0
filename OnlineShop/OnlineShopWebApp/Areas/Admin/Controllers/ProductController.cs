using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;

        }
        public IActionResult Index()
        {
            var products = productsStorage.GetAll();

            return View(products);
        }


        public IActionResult DeleteProduct(int id)
        {
            var product = productsStorage.TryGetProduct(id);
            if (product != null)
            {
                productsStorage.Delete(id);
            }
            return RedirectToAction("Index", "Product");
        }

        public IActionResult EditProduct(int id)
        {
            var product = productsStorage.TryGetProduct(id);

            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                productsStorage.SaveEditedProduct(newProduct);
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
            productsStorage.Add(product);
            return RedirectToAction("Index", "Product");
        }

    }
}