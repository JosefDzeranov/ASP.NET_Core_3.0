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
        private readonly DataStorage productData;
        public ProductController()
        {
            productData = new DataStorage();
        }
        public IActionResult Index(int id)
        {
            var products = productData.GetProductDataFromXML();
            var product = products.Where(p => p.Id == id);      
          
            return View(product);
        }
    }
}
