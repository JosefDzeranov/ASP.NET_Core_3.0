using System;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage _productStorage;
        public ProductController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
        public IActionResult Index(string productId)
        {
            var product = _productStorage?.TryGetProduct(productId);
            return View(product);
        }
    }
}
