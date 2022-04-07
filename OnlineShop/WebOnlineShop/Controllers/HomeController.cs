using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebOnlineShop.Models;

namespace WebOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository productRepository;
        public HomeController()
        {
            productRepository = new ProductRepository();
        }

        public string Index()
        {
            var products = productRepository.GetProducts();
            var result = "";
            foreach (var product in products)
            {
                result += product + "\n\n";
            }
            return result;
        }
        
    }
}