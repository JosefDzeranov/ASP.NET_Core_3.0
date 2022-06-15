using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Models;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var products = await productRepository.GetAllAsync();
            var productsViewModel = products.MappingToListProductViewModel();
            return View(productsViewModel);
        }


        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await productRepository.TryGetByIdAsync(id);
            if (product != null)
            {
                await productRepository.DeleteAsync(product);
            }
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> EditProduct(Guid id)
        {
            var product = await productRepository.TryGetByIdAsync(id);
            var editProductViewModel = product.MappingToEditProductViewModel();
            return View(editProductViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductViewModel editProductViewModel)
        {
            if (ModelState.IsValid)
            {
                if (editProductViewModel.UploadedImages != null)
                {
                    var imagesPaths = filesUploader.SaveFiles(editProductViewModel.UploadedImages, Const.ImagesDirectory);

                    var productDb = editProductViewModel.MappingToProduct(imagesPaths);
                    await productRepository.UpdateAsync(productDb);
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
        public async Task<IActionResult> AddProduct(AddProductViewModel addProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var imagesPaths = filesUploader.SaveFiles(addProductViewModel.UploadedImages, Const.ImagesDirectory);

                var productDb = addProductViewModel.MappingToProduct(imagesPaths);
                await productRepository.AddAsync(productDb);
                return RedirectToAction("Index", "Product");
            }

            return View(addProductViewModel);
        }


    }
}
