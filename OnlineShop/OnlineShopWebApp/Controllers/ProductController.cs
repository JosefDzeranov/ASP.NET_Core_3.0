using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Helpers;

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
            var productViewModel = product.ToProductViewModel();
            return View(productViewModel);
        }
    }
}
