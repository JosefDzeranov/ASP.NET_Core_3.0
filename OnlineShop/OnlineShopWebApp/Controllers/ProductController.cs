using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductStorage ProductStorage { get; }
        public ProductController(IProductStorage productStorage)
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
