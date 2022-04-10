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
        private readonly ProductRepozitory productRepozitory;

        public ProductController()
        {
            productRepozitory = new ProductRepozitory();
        }
        public IActionResult Index(int id)
        {
           var product = productRepozitory.TryGetById(id);
           return View(product);
           //if (product == null)
           // {
               // return "Продукта с таким id не существует";
           // }
            //$"{product}\n{product.Description}";
            
                
                
        }
    }
}
