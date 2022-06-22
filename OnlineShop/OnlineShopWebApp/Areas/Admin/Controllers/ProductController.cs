using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;

namespace OnlineShop.Areas.Admin.Controllers
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


        public IActionResult DeleteProduct(Guid id)
        {
            var product = productsStorage.TryGetProduct(id);
            if (product != null)
            {
                productsStorage.Delete(id);
            }
            return RedirectToAction("Index", "Product");
        }

        public IActionResult EditProduct(Guid id)
        {
            var product = productsStorage.TryGetProduct(id);

            return View(product);
        }
    }
}