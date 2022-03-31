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
        public IActionResult Index(int id)
        {
            var data = new Data();
            var products = data.GetDataFromXML();
            var product = products.Where(p => p.Id == id);

            return View(product);
        }
    }
}
