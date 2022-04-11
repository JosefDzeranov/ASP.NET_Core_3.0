using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductBase productBase;

        public HomeController(IProductBase productBase)
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
