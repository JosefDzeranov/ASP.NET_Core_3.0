using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index(int id)
        {
            var data = new DataStorage();
            var product = data.TryGetProduct(id);           

            if (product == null)
            {           
                if(data.ProductBaskets.Count() == 0)
                {
                    return View("Empty");
                }
                return View(data);
            }

            data.AddProductBasket(product);
            return View(data);
        }
    }
}
