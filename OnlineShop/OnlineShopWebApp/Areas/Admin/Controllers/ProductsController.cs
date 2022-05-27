using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class ProductsController : Controller
    {
        private readonly IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var productsDb = _productManager.GetAll();
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in productsDb)
            {
                var productViewModels = new ProductViewModel
                {
                    Id = product.Id,
                    CodeNumber = product.CodeNumber,
                    Cost = product.Cost,
                    Description = product.Description,
                    Images = product.Images,
                    Length = product.Length,
                    Square = product.Square,
                    Width = product.Width
                };
                productsViewModels.Add(productViewModels);
            }

            return View(productsViewModels);
        }

        public IActionResult Delete(Guid productId)
        {
            var product = _productManager.Find(productId);
            _productManager.Delete(product);
            return RedirectToAction("Index");
        }

        public IActionResult CardUpdate(Guid productId)
        {
            var product = _productManager.Find(productId);;

            var productViewModels = new ProductViewModel
            {
                Id = product.Id,
                CodeNumber = product.CodeNumber,
                Cost = product.Cost,
                Description = product.Description,
                Images = product.Images,
                Length = product.Length,
                Square = product.Square,
                Width = product.Width
            };
            return View(productViewModels);
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("errorValid");

            }
            var productDb = new Product
            {
                Cost = productViewModel.Cost,
                Description = productViewModel.Description,
                CodeNumber = productViewModel.CodeNumber,
                Id = productViewModel.Id,
                Images = productViewModel.Images,
                Length = productViewModel.Length,
                Square = productViewModel.Square,
                Width = productViewModel.Width
            };
            _productManager.UpdateProduct(productDb);
            return RedirectToAction("Index");
        }
        public IActionResult CardNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("errorValid");
            }

            var productDb = new Product
            {
                Cost = productViewModel.Cost,
                Description = productViewModel.Description,
                CodeNumber = productViewModel.CodeNumber,
                Id = productViewModel.Id,
                Images = productViewModel.Images,
                Length = productViewModel.Length,
                Square = productViewModel.Square,
                Width = productViewModel.Width
            };

            _productManager.AddNew(productDb);
            return RedirectToAction("Index");
        }
    }
}
