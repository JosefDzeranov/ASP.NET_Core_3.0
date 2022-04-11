using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBase productBase;

        public ProductController(IProductBase productBase)
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
