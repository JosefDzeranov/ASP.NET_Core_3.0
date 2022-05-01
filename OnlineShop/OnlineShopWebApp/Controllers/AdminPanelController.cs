using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OOnlineShopWebApp.Controllers
{

    public class AdminPanelController : Controller
    {
        private readonly IProductStorage productStorage;
        public AdminPanelController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        public IActionResult Index(int personId)
        {
            return View();
        }
        public IActionResult Orders(int personId)
        {
            return View();
        }
        public IActionResult Users(int personId)
        {
            return View();
        }
        public IActionResult Roles(int personId)
        {
            return View();
        }
        public IActionResult Products(int personId)
        {
            var products = productStorage.Products;
            return View(products);
        }
        public IActionResult DeleteProduct(int productId, int userId)
        {
            return RedirectToAction("Products");
        }
        public IActionResult UpdateProduct(int productId, int userId)
        {
            return RedirectToAction("Products");
        }

        public IActionResult AddNewProduct(int userId)
        {
            return RedirectToAction("Products");
        }
    }
}
