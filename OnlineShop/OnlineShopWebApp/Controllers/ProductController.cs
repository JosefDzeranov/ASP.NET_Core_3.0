using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int id)
        {
            var requestedProduct = ProductsStorage.TryGetProduct(id);

            return View(requestedProduct);
        }
    }
}
