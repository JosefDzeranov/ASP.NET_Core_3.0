using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public AdministrationController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            productsRepository.Add(product);
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditData(int productId)
        {
            productsRepository.Edit(productId);
            return View();
        }
        public IActionResult Delete(int productId)
        {
            productsRepository.Delete(productId);
            return RedirectToAction("Products");
        }

    }
}
