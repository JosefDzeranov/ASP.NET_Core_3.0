using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;
        public ProductController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index(Guid productId)
        {
            var product = productStorage.FindProduct(productId);
            return View(product);
        }
    }
}
