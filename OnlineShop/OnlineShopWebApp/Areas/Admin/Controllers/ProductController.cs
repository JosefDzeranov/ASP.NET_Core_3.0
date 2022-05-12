using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductStorage _productStorage;
        public ProductController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
 
        public IActionResult Index()
        {
            var products = _productStorage.GetProductData();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productStorage.Add(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                _productStorage.Edit(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Remove(Guid id)
        {
            _productStorage.Remove(id);
            return RedirectToAction("Index"); ;
        }
    }
}
