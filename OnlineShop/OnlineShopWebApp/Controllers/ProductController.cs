using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.DataSources;
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
            var productSource = new ProductDataSource();

            var s = productSource.GetProductById(id)?.ToString();

            if (s!=null)
                return Ok(s);

            return BadRequest($"Продукт c ID № {id} не существует");
        }
    }
}
