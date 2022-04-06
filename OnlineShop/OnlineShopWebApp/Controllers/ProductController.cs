using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int id)
        {
            var requestedProduct = ProductsStorage.TryGetProduct(id);
            return View(requestedProduct);
        }
    }
}
