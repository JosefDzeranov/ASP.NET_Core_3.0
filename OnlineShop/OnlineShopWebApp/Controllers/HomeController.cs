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
        public IActionResult Index()
        {
            var products = StorageProducts.GetAll();
            //var result = string.Empty;

            //foreach (var product in products)
            //{
            //    result += product;
            //}
            //ViewBag.Products = result; //записать в свойстве
            //ViewData["Products"] = result; //по ключу
            //TempData["Products"] = result; //по ключу
            return View((object)products);
        }

        public IActionResult Privacy() 
        { 
            return View(); 
        }
    }
}
