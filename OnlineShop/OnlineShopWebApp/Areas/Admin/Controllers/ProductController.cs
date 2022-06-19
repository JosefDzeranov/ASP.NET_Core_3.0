using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Db.Models;
using OnlineShopWebApp.Helpers;
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
        public IActionResult EditProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = productViewModel.ToProduct();

                productsStorage.SaveEditedProduct(product);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Product");
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productViewModel)
        {
            var product = productViewModel.ToProduct();

            productsStorage.Add(product);

            return RedirectToAction("Index", "Product");
        }

    }
}