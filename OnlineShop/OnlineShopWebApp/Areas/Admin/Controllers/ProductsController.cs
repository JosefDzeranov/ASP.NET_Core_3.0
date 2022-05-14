using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductStorage productStorage;
        public ProductsController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index()
        {
            var products = productStorage.Products;
            return View(products);
        }

        public IActionResult DeleteProduct(Guid productId)
        {
            var product = productStorage.FindProduct(productId);
            productStorage.DeleteProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult CardUpdateProduct(Guid productId)
        {
            var oldProduct = productStorage.FindProduct(productId);
            return View(oldProduct);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productStorage.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            else return Content("errorValid");
        }
        public IActionResult CardNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productStorage.AddNewProduct(product);
                return RedirectToAction("Index");
            }
            return Content("errorValid");
        }
    }
}
