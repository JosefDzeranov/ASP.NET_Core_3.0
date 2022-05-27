using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;

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
            return View(productManager.GetAll());
        }
    }
}
