using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Diagnostics; 

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductDataSource productDataSource;
 
        public HomeController(IProductDataSource productDataSource)
        {
            this.productDataSource = productDataSource;
        }
        public IActionResult Index()
        {
            var products = productDataSource.GetAllProducts();

            return View(Mapping.ToProductViewModels(products));    
        }
    }
}
