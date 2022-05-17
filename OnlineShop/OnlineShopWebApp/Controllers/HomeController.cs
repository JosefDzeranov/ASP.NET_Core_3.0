using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartRepository;

        public HomeController(IProductsRepository productRepository, ICartsRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        public IActionResult Index()
        {
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            ViewBag.ProductCount = cart?.Amout;
            var products = productRepository.GetAllProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ProductSearch(string name)
        {
            if (name != null)
            {
                var productSearch = new List<Product>();
                productSearch = productRepository.GetAllProducts().FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
                return View(productSearch);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}