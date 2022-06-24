using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly IImageProvider _imageProvider;

        public ProductController(IProductStorage productStorage, IImageProvider imageProvider)
        {
            _productStorage = productStorage;
            _imageProvider = imageProvider;
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

            var imagePaths = _imageProvider.SaveFiles(model.UploadedFiles, ImageFolders.products);

            var product = model.ToProduct(imagePaths);
            _productStorage.Add(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            var editProductViewModel = product.ToEditProductViewModel();
            return View(editProductViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var imagePaths = _imageProvider.SaveFiles(model.UploadedFiles, ImageFolders.products);

            if (imagePaths != null)
            {
                model.ImagePaths = imagePaths;
            }

            var product = model.ToProduct();
            _productStorage.Edit(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid id)
        {
            _productStorage.Remove(id);
            return RedirectToAction(nameof(Index)); ;
        }
    }
}
