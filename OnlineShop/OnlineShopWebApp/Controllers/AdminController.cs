using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public AdminController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult AdminPanel()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Products()
        {
            productsRepository.GetAll();
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            productsRepository.Add(product);
            return RedirectToAction("Products");
        }
        public IActionResult Status()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
    }
}
