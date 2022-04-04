using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
           

            var products = ProductManager.GetAllProducts();

            return View(products);
        }

    }
}
