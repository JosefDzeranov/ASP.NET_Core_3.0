using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interface;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsStorage;

        private readonly ICartsStorage cartsStorage;

        public HomeController(IProductsStorage productsStorage, ICartsStorage cartsStorage)
        {
            this.productsStorage = productsStorage;

            this.cartsStorage = cartsStorage;
        }

        public IActionResult Index()
        {
            var products = productsStorage.GetAllFirst();

            return View(products);
        }
    }
}
