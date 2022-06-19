using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Db.Models;
using OnlineShopWebApp.Models;
using System;

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
        [HttpPost]
        public IActionResult EditProduct(ProductViewModel newProduct)
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
        public IActionResult AddProduct(ProductViewModel product)
        {
            productsStorage.Add(product);
            return RedirectToAction("Index", "Product");
        }

    }
}