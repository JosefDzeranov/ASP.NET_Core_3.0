using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;
using System;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var products = productsRepository.GetAllProducts();
            if (products == null || products.Count == 0)
                return View("notFound");
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid == false)
                return View(product);
            productsRepository.Add(product);
            return RedirectToAction("Products");
        }

        public IActionResult Edit(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            return View(product);

        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid == false)
                return View(product);
            productsRepository.Edit(product);
            return RedirectToAction("Products");
        }

        public IActionResult Clear(int productId)
        {
            productsRepository.Clear(productId);
            return RedirectToAction("Products");
        }
    }
}
