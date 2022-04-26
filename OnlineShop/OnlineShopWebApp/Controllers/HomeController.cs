using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage _productStorage;
        public HomeController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
        
        public IActionResult Index()
        {
            var products = _productStorage.GetProductData();
            return View(products);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            var products = _productStorage.SearchByName(name);

            if(products.Count() == 0)
            {
                return View("NotFound");
            }
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
