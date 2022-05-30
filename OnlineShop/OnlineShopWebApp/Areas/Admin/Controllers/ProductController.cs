using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;

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
            var products = _productStorage.GetAll();
            var productViewModels = products.ToProductViewModels();
            return View(productViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = productViewModel.ToProduct();
                _productStorage.Add(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            var productViewModel = product.ToProductViewModel();
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = productViewModel.ToProduct();
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
