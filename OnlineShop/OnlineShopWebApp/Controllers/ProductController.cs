using Microsoft.AspNetCore.Mvc;

namespace OnlineDesignBureauWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductCatalog productCatalog;
        public ProductController(ProductCatalog productCatalog)
        {
            this.productCatalog = productCatalog;
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
