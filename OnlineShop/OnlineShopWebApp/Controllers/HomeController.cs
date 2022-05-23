using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;

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
            var productViewModels = products.ToProductViewModels();
            return View(productViewModels);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            if(name == null)
            {
                return RedirectToAction("Index");
            }

            var products = _productStorage.SearchByName(name).ToList();
            var productViewModels = products.ToProductViewModels();
            
            if (!productViewModels.Any())
            {
                return View("NotFound");
            }

            return View(productViewModels);
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
