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
        public IActionResult Index(int id)
        {
            var product = productStorage.Products[id];
            return View (product);
        }
        public string Save(string name)
        {
            return productStorage.WriteToStorage();
        }
    }
}
