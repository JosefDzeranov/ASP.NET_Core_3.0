using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage _productStorage;
        public ProductController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
        public IActionResult Index(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                ImagePath = product.ImagePath,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
            return View(productViewModel);
        }
    }
}
