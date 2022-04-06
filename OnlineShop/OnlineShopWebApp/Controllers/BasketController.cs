using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index(int id)
        {
            var product = new DataStorage().GetProductDataFromXML()
                                           .Where(p => p.Id == id)
                                           .FirstOrDefault();
            var basket = new Basket();
            basket.AddToBasket(product, 1);
            return View(basket);
        }
    }
}
