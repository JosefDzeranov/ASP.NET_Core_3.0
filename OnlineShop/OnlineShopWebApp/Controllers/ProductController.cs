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
        private readonly ProductDataSource productDataSource;
      public ProductController()
		{
            productDataSource = new ProductDataSource();
		}
        public IActionResult Index(int id)
        {
      
            var product = productDataSource.GetProductById(id);
                return View(product);

        }
    }
}
