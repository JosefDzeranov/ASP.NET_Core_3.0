using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProdcutBase productBase;

        public ProductController(ProdcutBase productBase)
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
