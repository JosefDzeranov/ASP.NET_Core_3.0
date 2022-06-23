using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductStorage _productStorage;
        
        public ProductController(IProductStorage productStorage, IWebHostEnvironment appEnvironment)
        {
            _productStorage = productStorage;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var products = _productStorage.GetAll();
            var productViewModels = products.ToProductViewModels();
            return View(productViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var imagePath = imageProvider.SafeFiles(model.UploadedFiles, ImageFolders.Products);



                var product = model.ToProduct();
                _productStorage.Add(product);
                return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            var productViewModel = product.ToProductViewModel();
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UploadedFile != null)
                {
                    var productImagePath = Path.Combine(_appEnvironment.WebRootPath + "/img/products/");
                    var fileName = Guid.NewGuid() + "." + model.UploadedFile.FileName.Split(".").Last();

                    using (var fileStream = new FileStream(productImagePath + fileName, FileMode.Create))
                    {
                        model.UploadedFile.CopyTo(fileStream);
                    }
                    model.ImagePath = "/img/products/" + fileName;
                }

                var product = model.ToProduct();
                _productStorage.Edit(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Remove(Guid id)
        {
            _productStorage.Remove(id);
            return RedirectToAction(nameof(Index)); ;
        }
    }
}
