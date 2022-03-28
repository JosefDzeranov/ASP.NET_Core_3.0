using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int id)
        {
            var Products = ProdcutBase.Products;
            var product = Products.FirstOrDefault(p=> p.Id == id);

            
            return View(product);
        }
    }
}
