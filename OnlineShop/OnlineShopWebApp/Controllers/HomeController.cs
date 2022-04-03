using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly StorageProducts storageProducts;

        public HomeController()
        {
            storageProducts = new StorageProducts();
        }
        public string Index()
        {
            var products = StorageProducts.ShowProducts();
            var result = string.Empty;

            foreach (var product in products)
            {
                result += product + "\n\n";
            }
            return result;
        }

        public IActionResult Privacy() 
        { 
            return View(); 
        }
    }
}
