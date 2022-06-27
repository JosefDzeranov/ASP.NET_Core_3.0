using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;
using OnlineShop.Common.Interface;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWorkWithData _productRepositoryJson = new JsonWorkWithData("projects_for_sale");
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var productsDb = _productRepository.GetAll();
            var productsViewModels = new List<Product_ViewModel>();
            foreach (var product in productsDb)
            {
                var productViewModels = new Product_ViewModel
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
            var product = _productRepository.Find(productId);
            _productRepository.Delete(product);
            return RedirectToAction("Index");
        }

        public IActionResult CardUpdate(Guid productId)
        {
            var product = _productRepository.Find(productId);;

            var productViewModels = new Product_ViewModel
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
        public IActionResult Update(Product_ViewModel productViewModel)
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
            _productRepository.UpdateProduct(productDb);
            return RedirectToAction("Index");
        }
        public IActionResult CardNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Product_ViewModel productViewModel)
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

            _productRepository.AddNew(productDb);
            return RedirectToAction("Index");
        }

        public IActionResult CardNewProductsDefoult()
        {
            var productsJson = _productRepositoryJson.Read<List<Product>>();
            foreach (var productJson in productsJson)
            {
                _productRepository.AddNew(productJson);
            }
            return RedirectToAction("Index");
        }
    }
}
