using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

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
        public IActionResult DeleteProduct(int idProduct, int userId)
        {
            var product = productStorage.FindProduct(idProduct);
            productStorage.DeleteProduct(product, userId);
            return RedirectToAction("Products");
        }
        public IActionResult CardUpdateProduct(int idOldProduct, int userId)
        {
            var oldProduct = productStorage.FindProduct(idOldProduct);
            return View(oldProduct);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product oldProduct, Product newProduct, int userId)
        {
            productStorage.UpdateProduct(oldProduct, newProduct, userId);
            return RedirectToAction("Products");
        }
        public IActionResult CardNewProduct(int userId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(Product product, int userId)
        {
            productStorage.AddNewProduct(product, userId);
            return RedirectToAction("Products");
        }
    }
}
