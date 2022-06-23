using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsDbStorage;

        public HomeController(IProductsStorage productsDbStorage)
        {
            this.productsDbStorage = productsDbStorage;
        }

        public IActionResult Index()
        {
            var products = productsDbStorage.GetAllAvailable();
            var productViewModels = products.ToProductViewModels();
            return View(productViewModels);
            //var products = productsDbStorage.GetAllAvailable();

            //var productsViewModels = new List<ProductViewModel>();
            //foreach (var product in products)
            //{
            //    var productViewModel = new ProductViewModel
            //    {
            //        Id = product.Id,
            //        Name = product.Name,
            //        Cost = product.Cost,
            //        Description = product.Description,
            //        ImagePath = product.ImagePath
            //    };
            //    productsViewModels.Add(productViewModel);
            //}

            //return View(productsViewModels);
        }
    }
}
