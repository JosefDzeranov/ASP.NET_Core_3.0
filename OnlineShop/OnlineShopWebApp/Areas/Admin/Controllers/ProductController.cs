using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;

        }
        public IActionResult Index()
        {
            var products = productsStorage.GetAllAvailable();

            var productsViewModels = new List<ProductViewModel>();
            
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = product.ImagePath
                };
                productsViewModels.Add(productViewModel);
            }

            return View(productsViewModels);
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
            
            var productViewModel = product.ToProductViewModel();

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult SaveEditedProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = productViewModel.ToProduct();

                productsStorage.SaveEditedProduct(product);
            }

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }

    }
}