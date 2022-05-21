﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;
using OnlineShop.Db;
using System.Collections.Generic;
using OnlineShop.db.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductDataSource productDataSource;

        public ProductController(IProductDataSource productDataSource)
        {
            this.productDataSource = productDataSource;
        }

        public IActionResult Index()
        {
            var products = productDataSource.GetAllProducts();
            return View(Mapping.ToProductViewModels(products));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var productDb = new Product

            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };

            productDataSource.AddProduct(productDb);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Remove(int productId)
        {
            productDataSource.RemoveProduct(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var product = productDataSource.GetProductById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View (product);
               
            }
            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };

            productDataSource.EditProduct(productDb);
            return RedirectToAction(nameof(Index));
        }

    }
}
