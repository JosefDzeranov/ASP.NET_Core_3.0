using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductMemoryStorage productCatalog;
        public ProductController(IProductMemoryStorage productCatalog)
        {
            this.productCatalog = productCatalog;
        }
        public IActionResult Index(int id)
        {
            var product = productCatalog.Products[id];
            return View (product);
        }
        public string Save(string name)
        {
            return productCatalog.WriteToStorage();
        }
    }
}
