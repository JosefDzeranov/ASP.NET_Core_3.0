using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Filters;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(CheckingForAuthorization))]
    public class ProductsController : Controller
    {
        private readonly IProductManager productManager;
        public ProductsController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public IActionResult Index()
        {
            var productsDb = productManager.GetAll();
            
            return View(productsDb);
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
        public IActionResult Update(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("errorValid");

            }
            var productDb = new Product
            {
                Cost = productViewModel.Cost,
                Description = productViewModel.Description,
                CodeNumber = productViewModel.CodeNumber,
                Id = productViewModel.Id,
                Images = productViewModel.Images,
                Length = productViewModel.Length,
                Square = productViewModel.Square,
                Width = productViewModel.Width
            };
            productManager.UpdateProduct(productDb);
            return RedirectToAction("Index");
        }
        public IActionResult CardNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("errorValid");
            }

            var productDb = new Product
            {
                Cost = productViewModel.Cost,
                Description = productViewModel.Description,
                CodeNumber = productViewModel.CodeNumber,
                Id = productViewModel.Id,
                Images = productViewModel.Images,
                Length = productViewModel.Length,
                Square = productViewModel.Square,
                Width = productViewModel.Width
            };

            productManager.AddNew(productDb);
            return RedirectToAction("Index");
        }
    }
}
