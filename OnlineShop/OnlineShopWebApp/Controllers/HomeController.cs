using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        IProductManager _productManager;
        ICartManager cartManager;

        public HomeController(IProductManager productManager, ICartManager cartManager)
        {
            _productManager = productManager;
            this.cartManager = cartManager;
        }
        public IActionResult Index()
        {
           
            var products = _productManager.productList;
           

            return View(products);
        }

    }
}
