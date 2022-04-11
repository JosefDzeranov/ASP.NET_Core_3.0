using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductBase productBase;

        public ProductController(ProductBase productBase)
        {
            this.productBase = productBase;
        }
        public IActionResult Index(int id)
        {

            var product = productBase.TryGetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
