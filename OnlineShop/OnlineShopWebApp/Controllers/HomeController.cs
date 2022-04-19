using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        IProductManager _productManager;

        public HomeController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        public IActionResult Index()
        {

            var products = _productManager.productList;

            return View(products);
        }

    }
}
