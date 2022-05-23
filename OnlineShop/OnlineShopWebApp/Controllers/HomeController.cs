using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManager productManager;
        public HomeController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public IActionResult Index()
        {
            return View(productManager.Products);
        }
    }
}
