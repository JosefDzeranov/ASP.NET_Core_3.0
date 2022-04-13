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

        public ProductController()
        {
            productsRepozitory = new ProductsRepozitory();
        }
        public IActionResult Index(int id)
        {
           var product = productsRepozitory.TryGetById(id);
           return View(product);
           //if (product == null)
           // {
               // return "Продукта с таким id не существует";
           // }
            //$"{product}\n{product.Description}";
            
                
                
        }
    }
}
