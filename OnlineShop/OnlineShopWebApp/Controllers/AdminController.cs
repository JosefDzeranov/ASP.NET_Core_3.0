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
        private readonly IOrdersRepository ordersRepository;


        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult AdminPanel()
        {
            return View();
        }
        public IActionResult Orders()
        {
            var orders = ordersRepository.TryGetOrdersInformation();
            return View(orders);
        }
        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            productsRepository.Add(product);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            productsRepository.Update(product);
            return RedirectToAction("Products");
        }

        public IActionResult DeleteProduct(int productId)
        {
            productsRepository.Delete(productId);
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
