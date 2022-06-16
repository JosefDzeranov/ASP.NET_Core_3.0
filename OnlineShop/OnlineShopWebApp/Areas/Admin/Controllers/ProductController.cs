using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;        
        private readonly ImagesProvider imagesProvider;

        public ProductController(IProductsRepository productsRepository, ImagesProvider imagesProvider)
        {
            this.productsRepository = productsRepository;            
            this.imagesProvider = imagesProvider;
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

            var imagesPaths = imagesProvider.SaveFiles(product.UploadedFiles, ImagesFolders.products);
            productsRepository.Add(product.ToProduct(imagesPaths));
            return RedirectToAction("Products");
        }

        public IActionResult Edit(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(Mapping.ToEditProductViewModel(product));
        }


        [HttpPost]
        public IActionResult Edit(EditProductViewModel changedProduct)
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

            if (changedProduct.UploadedFiles != null)
            {
                var newImages = imagesProvider.SaveFiles(changedProduct.UploadedFiles, ImagesFolders.products);
                foreach (var newImage in newImages)
                {
                    product.Images.Add(new Image { Url = newImage });
                }                                       
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
