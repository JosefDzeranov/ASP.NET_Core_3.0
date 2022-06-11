using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles = Const.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IFilesUploader filesUploader;

        public ProductController(IProductRepository productRepository, IFilesUploader filesUploader)
        {
            this.productRepository = productRepository;
            this.filesUploader = filesUploader;

        }
        public IActionResult Index()
        {
            var products = productRepository.GetAll();
            var productsViewModel = products.MappingToListProductViewModel();
            return View(productsViewModel);
        }


        public IActionResult DeleteProduct(Guid id)
        {
            var product = productRepository.TryGetById(id);
            if (product != null)
            {
                productRepository.Delete(product);
            }
            return RedirectToAction("Index", "Product");
        }

        public IActionResult EditProduct(Guid id)
        {
            var product = productRepository.TryGetById(id);
            var editProductViewModel = product.MappingToEditProductViewModel();
            return View(editProductViewModel);
        }
        [HttpPost]
        public IActionResult EditProduct(EditProductViewModel editProductViewModel)
        {
            if (ModelState.IsValid)
            {
                if (editProductViewModel.UploadedImages != null)
                {
                    var imagesPaths = filesUploader.SaveFiles(editProductViewModel.UploadedImages, Const.ImagesDirectory);

                    var productDb = editProductViewModel.MappingToProduct(imagesPaths);
                    productRepository.Update(productDb);
                }
                return RedirectToAction("Index", "Product");
            }
            return View(editProductViewModel);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel addProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var imagesPaths = filesUploader.SaveFiles(addProductViewModel.UploadedImages, Const.ImagesDirectory);
                 
                var productDb = addProductViewModel.MappingToProduct(imagesPaths);
                productRepository.Add(productDb);
                return RedirectToAction("Index", "Product");
            }
         
            return View(addProductViewModel);
        }


    }
}
