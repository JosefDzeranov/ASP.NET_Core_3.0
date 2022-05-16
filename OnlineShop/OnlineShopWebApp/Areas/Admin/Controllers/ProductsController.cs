using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductStorage ProductStorage;
        public ProductsController(IProductStorage productStorage)
        {
            this.ProductStorage = productStorage;
        }

        public IActionResult Index()
        {
            var products = ProductStorage.Products;
            return View(products);
        }

        public IActionResult Delete(Guid productId)
        {
            var product = ProductStorage.FindProduct(productId);
            ProductStorage.DeleteProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult CardUpdate(Guid productId)
        {
            var oldProduct = ProductStorage.FindProduct(productId);
            return View(oldProduct);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductStorage.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            else return Content("errorValid");
        }
        public IActionResult CardNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductStorage.AddNewProduct(product);
                return RedirectToAction("Index");
            }
            return Content("errorValid");
        }
    }
}
