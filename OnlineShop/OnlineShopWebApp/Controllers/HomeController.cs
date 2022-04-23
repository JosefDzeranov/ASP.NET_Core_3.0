using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage productStorage;
        public HomeController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        public IActionResult Index()
        {
            return View(productStorage.Products);
        }
    }
}
