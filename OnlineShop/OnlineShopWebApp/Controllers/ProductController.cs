using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProdcutBase productBase;

        public ProductController()
        {
            productBase = new ProdcutBase();
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
