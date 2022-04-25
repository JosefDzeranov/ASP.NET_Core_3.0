using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using System.Linq;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index(Product.Category categoryName)
        {
            

            if (categoryName != 0)
            {
                var filteredPoducts = productRepository.GetAll().Where(x => x.CategoryName == categoryName);
                return View(filteredPoducts);
            }
            else
            {
                var products = productRepository.GetAll();
                return View(products);
            }

           
        }
        [HttpPost]
        public IActionResult Filter(Product.Category categoryName)
        {
            
            
            return RedirectToAction("Index", categoryName);
        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}
