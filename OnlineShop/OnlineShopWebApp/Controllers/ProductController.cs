using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepozitory productsRepozitory;

        public ProductController(IProductsRepozitory productsRepozitory)
        {
            this.productsRepozitory = productsRepozitory;
        }
        public IActionResult Index(int id)
        {
            var product = productsRepozitory.TryGetById(id);
            return View(product);
        }
        public IActionResult Compare()
        {
            var productsToCompare = productsRepozitory.Compare();
            return View(productsToCompare);
        }
        public IActionResult AddToCompare(int productId)
        {
            var product = productsRepozitory.TryGetById(productId);
            productsRepozitory.AddToCompare(product);
            return RedirectToAction("Compare");
        }

        public IActionResult ClearCompare()
        {
            productsRepozitory.ClearCompare();
            return RedirectToAction("Compare");
        }
        public IActionResult DeleteComparingProduct(int productId)
        {
            var product = productsRepozitory.TryGetById(productId);
            productsRepozitory.DeleteComparingProduct(product);
            return RedirectToAction("Compare");
        }
    }
}
