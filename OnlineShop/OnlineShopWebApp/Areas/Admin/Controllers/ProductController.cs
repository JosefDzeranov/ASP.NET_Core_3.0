using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IWebHostEnvironment appEnvironment;

        public ProductController(IProductsRepository productsRepository, IWebHostEnvironment appEnvironment)
        {
            this.productsRepository = productsRepository;
            this.appEnvironment = appEnvironment;
        }

        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(Mapping.ToProductViewModels(products));
        }

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

            if (product.UploadedFile != null)
            {
                string productImagePath = Path.Combine(appEnvironment.WebRootPath + "/images/products/");
                if (!Directory.Exists(productImagePath))
                {
                    Directory.CreateDirectory(productImagePath);
                }

                var fileName = Guid.NewGuid() + "." + product.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
                {
                    product.UploadedFile.CopyTo(fileStream);
                }

                var productDb = new Product
                {                    
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    Pages = product.Pages,
                    ImagePath = "/images/products/" + fileName
                };

                productsRepository.Add(productDb);
            }
            return RedirectToAction("Products");
        }

        public IActionResult Edit(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(Mapping.ToProductViewModel(product));
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                Pages = product.Pages
            };

            if (ModelState.IsValid)
            {
                productsRepository.Edit(productDb);
                return RedirectToAction("Products");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Delete(Guid productId)
        {
            productsRepository.Delete(productId);
            return RedirectToAction("Products");
        }
    }
}
