using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager productManager;
        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public IActionResult Index(Guid productId)
        {
            var product = productManager.FindProduct(productId);
            return View(product);
        }
    }
}
