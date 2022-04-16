using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = CartBase.TryGetByUserId(TestUser.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = ProductBase.AllProducts().FirstOrDefault(x => x.Id == productId);
            CartBase.Add(product, TestUser.UserId);
            return RedirectToAction("Index");
        }
    }
}
