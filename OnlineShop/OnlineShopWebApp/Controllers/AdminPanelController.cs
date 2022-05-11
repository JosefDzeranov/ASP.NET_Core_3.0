using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OOnlineShopWebApp.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IProductStorage productStorage;
        private readonly IBuyerStorage buyerStorage;
        public AdminPanelController(IProductStorage productStorage, IBuyerStorage buyerStorage)
        {
            this.productStorage = productStorage;
            this.buyerStorage = buyerStorage;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders()
        {
            var orders = buyerStorage.CollectAllOrders();
            return View(orders);
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = productStorage.Products;
            return View(products);
        }
        public IActionResult DeleteProduct(int productId)
        {
            var product = productStorage.FindProduct(productId);
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
            if (ModelState.IsValid)
            {
                productStorage.UpdateProduct(product);
                return RedirectToAction("Products");
            }
            else return Content("errorValid");
        }
        public IActionResult CardNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productStorage.AddNewProduct(product);
                return RedirectToAction("Products");
            }
            else return Content("errorValid");
            
        }
    }
}
