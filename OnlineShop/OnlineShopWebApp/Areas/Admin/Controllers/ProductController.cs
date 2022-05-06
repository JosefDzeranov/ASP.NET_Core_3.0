using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                productsRepository.Add(product);
                return RedirectToAction("Products");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Edit(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productsRepository.Edit(product);
                return RedirectToAction("Products");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Delete(int productId)
        {
            productsRepository.Delete(productId);
            return RedirectToAction("Products");
        }
    }
}
