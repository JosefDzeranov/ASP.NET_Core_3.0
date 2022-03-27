using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index(int id)
        {
            string s = null;
            if (id == 0)
            {
                
                foreach (Product p in ProdcutBase.Products)
                {
                    s += $"Id{p.Id}\nName{p.Name}\nCost{p.Cost}\n\n";
                }
                return s;
            }
            else
            {
                foreach (Product p in ProdcutBase.Products)
                {
                    if (p.Id == id)
                    {
                        return $"Id{p.Id}\nName{p.Name}\nCost{p.Cost}\nDescription{p.Description}";
                    }
                }
                return s;
            }

          
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
