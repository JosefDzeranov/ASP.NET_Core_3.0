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
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id = 0)
        {
            var xDoc = XDocument.Load("Models/products.xml");
            var validData = xDoc.Element("products")
                               .Elements("product");
            if (id != 0)
            {
                validData = validData.Where(p =>int.Parse(p.Element("id").Value) == id);
            }
            
            var products = validData.Select(p => new Product(
                                       int.Parse(p.Element("id").Value),
                                       p.Element("name").Value,
                                       decimal.Parse(p.Element("cost").Value))).ToList();
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
