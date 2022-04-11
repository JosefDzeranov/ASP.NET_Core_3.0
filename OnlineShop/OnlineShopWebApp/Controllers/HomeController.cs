using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProductBase productBase;

        public HomeController(ProductBase productBase)
        {
            this.productBase = productBase;
        }
        public IActionResult Index()
        {
            var products = productBase.GetAll();
            
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
