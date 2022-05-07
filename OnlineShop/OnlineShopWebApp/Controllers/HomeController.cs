using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

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
            return View(products);
        }
    }
}
