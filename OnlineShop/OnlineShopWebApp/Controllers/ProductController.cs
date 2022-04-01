using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int id)
        {
            var product = new DataStorage().GetProductDataFromXML()
                                           .Where(p => p.Id == id);    
          
            return View(product);
        }
    }
}
