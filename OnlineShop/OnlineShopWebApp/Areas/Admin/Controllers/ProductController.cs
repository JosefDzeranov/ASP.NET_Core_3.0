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
        public IActionResult Add(AddProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            if (product.UploadedFiles.Count != 0)
            {
                var folderPath = ImagesProvider.GetFolderPath("products");               

                var fileName = Guid.NewGuid() + "." + product.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(folderPath + fileName, FileMode.Create))
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
            return View(new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Pages = product.Pages,
                Cost = product.Cost,
                ImagePath = product.ImagePath
            });
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel changedProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(changedProduct);
            }

            var product = productsRepository.TryGetById(changedProduct.Id);

            product.Id = changedProduct.Id;
            product.Name = changedProduct.Name;
            product.Cost = changedProduct.Cost;
            product.Description = changedProduct.Description;
            product.Pages = changedProduct.Pages;

            if (changedProduct.UploadedFile != null)
            {
                FileInfo fileInfo = new FileInfo(Path.Combine(appEnvironment.WebRootPath + product.ImagePath));
                fileInfo.Delete();
                string productImagePath = Path.Combine(appEnvironment.WebRootPath + "/images/products/");
                var fileName = Guid.NewGuid() + "." + changedProduct.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
                {
                    changedProduct.UploadedFile.CopyTo(fileStream);
                }

                product.ImagePath = "/images/products/" + fileName;                
            }           

            productsRepository.Edit();       
            return RedirectToAction("Products");                                   
        }

            public IActionResult Delete(Guid productId)
            {
                productsRepository.Delete(productId);
                return RedirectToAction("Products");
            }
        }
    }
