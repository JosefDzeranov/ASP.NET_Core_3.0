using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepozitory productRepozitory;

        public CartController()
        {
            productRepozitory = new ProductsRepozitory();
        }

        public IActionResult Index()
        {
            var cart = CartsRepozitory.TryGetByUserId(Constants.UserId);
            return View(cart);
        }   
        public IActionResult Add(int productId)
        {
            var product = productRepozitory.TryGetById(productId);
            CartsRepozitory.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
