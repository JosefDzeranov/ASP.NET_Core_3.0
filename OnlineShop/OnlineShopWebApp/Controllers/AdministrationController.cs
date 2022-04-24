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
            var productList = productManager.productList;
            return View(productList);
        }

        public IActionResult EditProduct(int id)
        {
            var product = productManager.FindProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult SaveEditedProduct(int id, string name, string cost, string description)
        {

            foreach (var product in productManager.productList)
            {
                if (product.Id == id)
                {
                    product.Name = name;
                    product.Cost = decimal.Parse(cost);
                    product.Description = description;

                }
            }

            return View();
        }

        public IActionResult RemoveProduct(int id)
        {
            var product = productManager.FindProduct(id);
            productManager.productList.Remove(product);
            return View(product);
        }

        public IActionResult AddNewProduct()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult SaveAddedProduct(string id, string name, string cost, string description)
        {

            var product = new Product(int.Parse(id), name, decimal.Parse(cost), description);
            productManager.productList.Add(product);
           

            return View(product);
        }
    }

}