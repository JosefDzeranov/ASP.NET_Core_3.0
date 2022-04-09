using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProdcutBase prodcutBase;

        public HomeController()
        {
            prodcutBase = new ProdcutBase();
        }
        public IActionResult Index()
        {
            var products = prodcutBase.GetAll();
            
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
