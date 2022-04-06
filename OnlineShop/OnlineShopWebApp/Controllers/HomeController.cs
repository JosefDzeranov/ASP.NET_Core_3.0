using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            var products = ProductsStorage.GetAllProducts();
            var output = string.Empty;
            foreach (var product in products)
            {
                output += product + "\n\n";
            }
            return output;
        }
    }
}
