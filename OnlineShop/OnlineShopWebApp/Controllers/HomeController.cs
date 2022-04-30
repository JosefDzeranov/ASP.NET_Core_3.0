using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductBase _productBase;

        public HomeController(IProductBase productBase)
        {
            _productBase = productBase;
        }

        public IActionResult Index()
        {
            var products = _productBase.AllProducts();
            return View(products);
        }

        public IActionResult SearchByName(string searchName)
        {
            if(string.IsNullOrEmpty(searchName))
            {
                searchName = String.Empty;
            }
            else
            {
                searchName.ToLower();
            }
            var products = _productBase.AllProducts().Where(x => x.Name.Contains(searchName));
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
