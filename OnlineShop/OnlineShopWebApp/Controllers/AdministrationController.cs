using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IProductManager productManager;

        public AdministrationController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public IActionResult Index()
        {

            return View("Orders");
        }

        public IActionResult Orders()
        {

            return View();
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
            var productList = productManager.ProductList;
            return View(productList);
        }

        public IActionResult EditProduct(int id)
        {
            var product = productManager.FindProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult SaveEditedProduct(Product product)
        {
            productManager.EditProduct(product);

            return View();
        }

        public IActionResult RemoveProduct(int id)
        {
            var product = productManager.FindProduct(id);
            productManager.ProductList.Remove(product);
            return View(product);
        }

        public IActionResult AddNewProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SaveAddedProduct(Product product)
        {
            productManager.ProductList.Add(product);

            return View(product);
        }
    }

}