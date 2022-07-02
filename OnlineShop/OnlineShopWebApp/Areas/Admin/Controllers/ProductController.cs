using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.db;
using OnlineShop.db.Models;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductDataSource productDataSource;
        private readonly ImagesProvider imagesProvider;

        public ProductController(IProductDataSource productDataSource, ImagesProvider imagesProvider)
        {
            this.productDataSource = productDataSource;
            this.imagesProvider = imagesProvider;
        }

        public IActionResult Index()
        {
            var products = productDataSource.GetAllProducts();
            return View(Mapping.ToProductViewModels(products));
        }

        [HttpGet]
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

            var imagesPath = imagesProvider.SafeFiles(product.UploadFiles, ImageFolders.Products);
            productDataSource.AddProduct(product.ToProduct(imagesPath));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int productId)
        {
            productDataSource.RemoveProduct(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var product = productDataSource.GetProductById(productId);
            return View(product.ToEditProductViewModel());
        }
        [HttpPost]
        public IActionResult Edit(EditProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var addedImagesPath = imagesProvider.SafeFiles(product.UploadFiles, ImageFolders.Products);
            product.ImagesPaths = addedImagesPath;
            productDataSource.Update(product.ToProduct());
            return RedirectToAction(nameof(Index));
        }
    }
}
