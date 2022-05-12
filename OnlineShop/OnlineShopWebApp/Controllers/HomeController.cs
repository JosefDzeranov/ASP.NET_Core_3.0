using Microsoft.AspNetCore.Mvc;
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
            var products = _productStorage?.GetProductData();
            return View(products);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            if(name == null)
            {
                return RedirectToAction("Index");
            }

            var products = _productStorage.SearchByName(name);

            if (!products.Any())
            {
                return View("NotFound");
            }

            return View(products);
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
