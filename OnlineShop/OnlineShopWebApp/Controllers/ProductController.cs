using Microsoft.AspNetCore.Mvc;
using System;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductCatalog productCatalog;
        public ProductController()
        {
            productCatalog = new ProductCatalog();
        }
        public IActionResult Index(int id)
        {
            var product = ProductCatalog.products[id];
            return View (product);
        }
        public string Save(string name)
        {
            return productCatalog.WriteToJson();
        }
    }
}
