using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBase _productBase;

        public ProductController(IProductBase productBase)
        {
            _productBase = productBase;
        }

        public IActionResult Index(int id)
        {
            var products = _productBase.AllProducts().FirstOrDefault(p => p.Id == id);
            return View(products);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productBase.Add(product);
            return RedirectToAction("Products", "Admin");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
