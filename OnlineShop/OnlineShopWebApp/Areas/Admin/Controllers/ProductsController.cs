using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductManager productManager;
        public ProductsController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public IActionResult Index()
        {
            var products = productManager.Products;
            return View(products);
        }

        public IActionResult Delete(Guid productId)
        {
            var product = productManager.Find(productId);
            productManager.Delete(product);
            return RedirectToAction("Index");
        }

        public IActionResult CardUpdate(Guid productId)
        {
            var oldProduct = productManager.Find(productId);
            return View(oldProduct);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                productManager.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            else return Content("errorValid");
        }
        public IActionResult CardNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Product product)
        {
            if (ModelState.IsValid)
            {
                productManager.AddNew(product);
                return RedirectToAction("Index");
            }
            return Content("errorValid");
        }
    }
}
