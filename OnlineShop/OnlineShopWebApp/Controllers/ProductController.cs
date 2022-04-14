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
        private readonly ProductsRepozitory productsRepozitory;

        public ProductController(ProductsRepozitory productsRepozitory)
        {
            this.productsRepozitory = productsRepozitory;
        }
        public IActionResult Index(int id)
        {
            var product = productsRepozitory.TryGetById(id);
            return View(product);



        }
    }
}
