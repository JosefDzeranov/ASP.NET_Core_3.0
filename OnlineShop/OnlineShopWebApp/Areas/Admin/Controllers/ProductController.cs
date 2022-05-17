using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

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
            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    ImagePath = product.ImagePath,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description
                };
                productViewModels.Add(productViewModel);
            }
            return View(productViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDb = new Product
                {
                    ImagePath = product.ImagePath,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description
                };

                _productStorage.Add(productDb);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                ImagePath = product.ImagePath,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Save(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDb = new Product
                {
                    Id = product.Id,
                    ImagePath = product.ImagePath,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description
                };

                _productStorage.Edit(productDb);
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
