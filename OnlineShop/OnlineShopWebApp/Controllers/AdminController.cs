using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {

        private readonly IProductsRepository productReposititory;

        public AdminController(IProductsRepository productsRepository)
        {
            this.productReposititory = productsRepository;
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
            var products = productReposititory.GetAll();
            return View(products);
        }
        public IActionResult Status()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
