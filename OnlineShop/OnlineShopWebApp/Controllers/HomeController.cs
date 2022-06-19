using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Interface;

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
            var products = productsStorage.GetAll();

            return View(products);
        }
    }
}
