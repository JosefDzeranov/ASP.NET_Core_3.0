using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsDbStorage;

        private readonly ICartsStorage cartsDbStorage;

        public HomeController(IProductsStorage productsDbStorage, ICartsStorage cartsDbStorage)
        {
            this.productsDbStorage = productsDbStorage;

            this.cartsDbStorage = cartsDbStorage;
        }

        public IActionResult Index()
        {
            var products = productsDbStorage.GetAllAvailable();

            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = product.ImagePath
                };
                productsViewModels.Add(productViewModel);
            }

            return View(productsViewModels);
        }
    }
}
