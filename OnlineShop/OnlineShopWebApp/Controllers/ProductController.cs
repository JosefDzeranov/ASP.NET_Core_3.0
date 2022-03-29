using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
      
        public IActionResult Index(int id)
        {
            var list = new List<Product>();

            var product1 = new Product() { Id = 1, Name = "1", Cost = 1, Description = "1" };
            var product2 = new Product() { Id = 2, Name = "2", Cost = 2, Description = "2" };
            var product3 = new Product() { Id = 3, Name = "3", Cost = 3, Description = "3" };

            list.Add(product1);
            list.Add(product2);
            list.Add(product3);

            var s = list.FirstOrDefault(x => x.Id == id);

            if (s!=null)
                return Ok(s);

            return BadRequest("Продукт не найден");
        }
    }
}
