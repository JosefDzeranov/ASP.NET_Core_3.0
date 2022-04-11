using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsStorage productsStorage;

        public ProductController (ProductsStorage productsStorage)
        {
            this.productsStorage = productsStorage;
        }
        public IActionResult Index(int id)
        {
            var requestedProduct = productsStorage.TryGetProduct(id);

            return View(requestedProduct);
        }
    }
}
