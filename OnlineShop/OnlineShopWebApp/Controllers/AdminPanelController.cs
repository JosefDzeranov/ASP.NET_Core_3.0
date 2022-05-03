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
        public IActionResult DeleteProduct(int idProduct)
        {
            var product = productStorage.FindProduct(idProduct);
            productStorage.DeleteProduct(product);
            return RedirectToAction("Products");
        }
        public IActionResult CardUpdateProduct(int productId)
        {
            var oldProduct = productStorage.FindProduct(productId);
            return View(oldProduct);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            productStorage.UpdateProduct(product);
            return RedirectToAction("Products");
        }
        public IActionResult CardNewProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            productStorage.AddNewProduct(product);
            return RedirectToAction("Products");
        }
    }
}
