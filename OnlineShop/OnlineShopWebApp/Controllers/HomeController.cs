using OnlineShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = productRepository.GetAll();
            
            return View(products);
        }

       


    }
}
