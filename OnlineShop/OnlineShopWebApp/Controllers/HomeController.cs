using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManager _productManager;
        public HomeController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var productsDb = _productManager.GetAll();
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in productsDb)
            {
                var productViewModels = new ProductViewModel
                {
                    Id = product.Id,
                    CodeNumber = product.CodeNumber,
                    Cost = product.Cost,
                    Description = product.Description,
                    Images = product.Images,
                    Length = product.Length,
                    Square = product.Square,
                    Width = product.Width
                };
                productsViewModels.Add(productViewModels);
            }
            return View(productsViewModels);
        }
    }
}
