using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductStorage ProductStorage { get; }
        public ProductController(ProductStorage productStorage)
        {
            ProductStorage = productStorage;
        }
        public IActionResult Index(int id)
        {
            var product = ProductStorage.TryGetProduct(id);              
            return View(product);
        }
    }
}
