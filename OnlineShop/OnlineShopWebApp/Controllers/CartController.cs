using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProdcutBase prodcutBase;
        public CartController()
        {
            prodcutBase = new ProdcutBase();
        }
        public IActionResult Index(int id)
        {

            return View();
        }
    }
}
