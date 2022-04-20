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
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index(int id)
        {
            var product = productsRepository.TryGetById(id);
            return View(product);
        }
        public IActionResult Compare()
        {
            var productsToCompare = productsRepository.Compare();
            return View(productsToCompare);
        }
        public IActionResult AddToCompare(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            productsRepository.AddToCompare(product);
            return RedirectToAction("Compare");
        }

        public IActionResult ClearCompare()
        {
            productsRepository.ClearCompare();
            return RedirectToAction("Compare");
        }
        public IActionResult DeleteComparingProduct(int productId)
        {
            productsRepository.DeleteComparingProduct(productId);
            return RedirectToAction("Compare");
        }
    }
}
