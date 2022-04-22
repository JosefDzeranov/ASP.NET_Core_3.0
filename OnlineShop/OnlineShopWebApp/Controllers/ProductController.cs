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
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index(int id)
        {
            var product = productsRepository.TryGetById(id);
            return View(product);
        }

        public IActionResult Delete(int productId)
        {
            productsRepository.Delete(productId);
            return View("Views/Administration/Products.cshtml");
        }
        public IActionResult AddNew ()
        {
            return View();
        }
        public IActionResult Add(Information information)
        {
            productsRepository.Add(information);
            return View();
        }
    }
}
