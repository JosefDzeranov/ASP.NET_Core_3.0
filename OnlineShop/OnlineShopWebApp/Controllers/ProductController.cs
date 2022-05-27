using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;

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
            var product = productManager.Find(productId);
            return View(product);
        }
    }
}
