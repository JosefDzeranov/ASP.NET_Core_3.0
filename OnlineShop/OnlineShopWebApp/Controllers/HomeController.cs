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
        List<ProductList> productLists;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productLists = new List<ProductList>
             {
                new ProductList { Id = 1, Name= "Дебетовая карта №1", Cost=100, Description = "Молодежная карта. Для тех, кому от 14 лет до 21 года" },
                new ProductList { Id = 2, Name= "Дебетовая карта №2", Cost=150, Description = "Золотая карта. Бесплатное обслуживание с подпиской, также по подписке процент на остаток" },
                new ProductList { Id = 3, Name= "Кредитная карта №1", Cost=200, Description = "Процетная ставка голодых 20% на покупки, платежи, снятие наличных и переводы" },
            };
        }
        public string Index()
        {
            var s = string.Empty;
            foreach (var product in productLists)
            {
                s += $"{product.Id}\n{product.Cost}\n{product.Name}\n\n";
            }
            return s;
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
