using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
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

        //public IActionResult Edit(Guid productId)
        //{
        //    var product = productsRepository.TryGetById(productId);
        //    return View(new ProductViewModel
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Description = product.Description,
        //        Pages = product.Pages,
        //        Cost = product.Cost,
        //        ImagePath = product.ImagePath
        //    });
        //}
        //[HttpPost]
        //public IActionResult Edit(ProductViewModel changedProduct)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(changedProduct);
        //    }

        //    var product = productsRepository.TryGetById(changedProduct.Id);

        //    product.Id = changedProduct.Id;
        //    product.Name = changedProduct.Name;
        //    product.Cost = changedProduct.Cost;
        //    product.Description = changedProduct.Description;
        //    product.Pages = changedProduct.Pages;

        //    if (changedProduct.UploadedFile != null)
        //    {
        //        FileInfo fileInfo = new FileInfo(Path.Combine(appEnvironment.WebRootPath + product.ImagePath));
        //        fileInfo.Delete();
        //        string productImagePath = Path.Combine(appEnvironment.WebRootPath + "/images/products/");
        //        var fileName = Guid.NewGuid() + "." + changedProduct.UploadedFile.FileName.Split('.').Last();
        //        using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
        //        {
        //            changedProduct.UploadedFile.CopyTo(fileStream);
        //        }

        //        product.ImagePath = "/images/products/" + fileName;                
        //    }           

        //    productsRepository.Edit();       
        //    return RedirectToAction("Products");                                   
        //}

        public IActionResult Delete(Guid productId)
        {
            productsRepository.Delete(productId);
            return RedirectToAction("Products");
        }
    }
}
