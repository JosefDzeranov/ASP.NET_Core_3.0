using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;

        public ProductController(IProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }
        public IActionResult Index(Guid id)
        {
            var requestedProduct = productsStorage.TryGetProduct(id);

            return View(requestedProduct);
        }
    }
}
