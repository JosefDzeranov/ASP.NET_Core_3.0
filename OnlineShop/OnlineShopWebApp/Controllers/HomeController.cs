using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsStorage.GetAllProducts();
            return View(products);
        }
    }
}
