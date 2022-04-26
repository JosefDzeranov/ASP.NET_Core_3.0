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
        public IActionResult Index(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            return View(product);
        }
    }
}
