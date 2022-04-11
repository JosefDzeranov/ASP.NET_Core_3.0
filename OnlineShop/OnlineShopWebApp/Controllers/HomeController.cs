using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private DataStorage Data { get; }
        public HomeController(DataStorage dataStorage)
        {
            Data = dataStorage;
        }

        public IActionResult Index()
        {           
            var products = Data.GetProductDataFromXML();
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
