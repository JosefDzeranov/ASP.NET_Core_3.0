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
        public IActionResult Index(List<Product> filteredPoducts)
        {
            var products = productRepository.GetAll();
            if (filteredPoducts.Count != 0)
            {

                products = filteredPoducts;
            }
            

            return View(products);
        }
        [HttpPost]
        public IActionResult Filter(int categoryName)
        {
            var filteredPoducts = productRepository.GetAll().Where(x => (int)x.CategoryName == categoryName);
            
            return RedirectToAction("Index", filteredPoducts);
        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}
