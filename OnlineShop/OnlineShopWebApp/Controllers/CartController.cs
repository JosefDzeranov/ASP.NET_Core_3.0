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
        private readonly IProductsRepozitory productsRepozitory;
        private readonly ICartsRepozitory cartsRepozitory;

        public CartController(IProductsRepozitory productsRepozitory, ICartsRepozitory cartsRepozitory)
        {
            this.productsRepozitory = productsRepozitory;
            this.cartsRepozitory = cartsRepozitory;
        }

        public IActionResult Index()
        {
            var cart = cartsRepozitory.TryGetByUserId(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepozitory.TryGetById(productId);
            cartsRepozitory.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Del(int productId)
        {
            var product = productsRepozitory.TryGetById(productId);
            cartsRepozitory.Del(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
