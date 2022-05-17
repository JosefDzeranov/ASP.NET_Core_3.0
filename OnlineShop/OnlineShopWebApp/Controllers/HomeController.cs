using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage _productStorage;
        public HomeController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public IActionResult Index()
        {
            var products = _productStorage.GetProductData();
            var productViewModels = new List<ProductViewModel>();
            foreach(var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    ImagePath = product.ImagePath,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description
                };
                productViewModels.Add(productViewModel);
            }
            return View(productViewModels);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            if(name == null)
            {
                return RedirectToAction("Index");
            }

            var products = _productStorage.SearchByName(name);
            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    ImagePath = product.ImagePath,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description
                };
                productViewModels.Add(productViewModel);
            }

            if (!productViewModels.Any())
            {
                return View("NotFound");
            }

            return View(productViewModels);
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
