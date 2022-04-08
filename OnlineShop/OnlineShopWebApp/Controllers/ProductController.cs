using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int id)
        {
            var product = new DataStorage().TryGetProduct(id);              
            return View(product);
        }
    }
}
