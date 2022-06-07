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
        private readonly IWebHostEnvironment appEnviroment;

        public ProductController(IProductRepository productRepository, IWebHostEnvironment appEnviroment)
        {
            this.productRepository = productRepository;
            this.appEnviroment = appEnviroment;

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
            var productViewModel = product.MappingToProductViewModel();
            return View(productViewModel);
        }
        [HttpPost]
        public IActionResult EditProduct(ProductViewModel productViewModel)
        {
            if (productViewModel.UploadedImg != null)
            {
                var productImagesDirectoryPath = Path.Combine(appEnviroment.WebRootPath + "/images/products");
                if (!Directory.Exists(productImagesDirectoryPath))
                {
                    Directory.CreateDirectory(productImagesDirectoryPath);
                }
                var imgFileName = Guid.NewGuid() + "." + productViewModel.UploadedImg.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagesDirectoryPath + imgFileName, FileMode.Create))
                {
                    productViewModel.UploadedImg.CopyTo(fileStream);
                }
                productViewModel.ImgPath = "/images/products" + imgFileName;
            }
            var productDb = productViewModel.MappingToProduct();
            productRepository.Update(productDb);
            return RedirectToAction("Index", "Product");
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                if(productViewModel.UploadedImg != null)
                {
                    var productImagesDirectoryPath = Path.Combine(appEnviroment.WebRootPath + "/images/products");
                    if (!Directory.Exists(productImagesDirectoryPath))
                    {
                        Directory.CreateDirectory(productImagesDirectoryPath);
                    }
                    var imgFileName = Guid.NewGuid() + "." + productViewModel.UploadedImg.FileName.Split('.').Last();
                    using (var fileStream = new FileStream(productImagesDirectoryPath + imgFileName, FileMode.Create))
                    {
                        productViewModel.UploadedImg.CopyTo(fileStream);
                    }
                    productViewModel.ImgPath = "/images/products" + imgFileName;
                   
                }
                var productDb = productViewModel.MappingToProduct();
                productRepository.Add(productDb);
                return RedirectToAction("Index", "Product");
            }
         
            return View(productViewModel);
        }

    }
}
