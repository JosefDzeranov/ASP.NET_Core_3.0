using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Index ()
        {
            var list = new List<Product>();

            var product1 = new Product() { Id = 1, Name = "1", Cost = 1};
            var product2 = new Product() { Id = 2, Name = "2", Cost = 2};
            var product3 = new Product() { Id = 3, Name = "3", Cost = 3};
          
            list.Add(product1);
            list.Add(product2);
            list.Add(product3);

            var s = string.Empty;

            foreach (var item in list)
            {
                s += $"Id{item.Id}\nName{item.Name}\nCost{item.Cost}\n\n";
            }
          
            return Ok(s);
        }

    }
}
