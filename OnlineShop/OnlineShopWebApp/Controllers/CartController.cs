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
        private readonly IProductBase _productBase;
        private readonly ICartBase _cartBase;


        public IActionResult Index()
        {
            var cart = _cartBase.TryGetByUserId(TestUser.UserId);
            return View(cart);
        }

        public CartController(IProductBase productBase, ICartBase cartBase)
        {
            _productBase = productBase;
            _cartBase = cartBase;
        }

        public IActionResult Add(int productId)
        {
            var product = _productBase.AllProducts().FirstOrDefault(x => x.Id == productId);
            _cartBase.Add(product, TestUser.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(int productId)
        {
            _cartBase.DecreaseAmount(productId, TestUser.UserId);
            return RedirectToAction("Index");
        }
    }
}
