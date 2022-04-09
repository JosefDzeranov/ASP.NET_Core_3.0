using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
           
            var products = ProductManager.GetAllProducts();

            return View(products);
        }

    }
}
