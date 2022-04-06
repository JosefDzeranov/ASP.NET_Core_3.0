using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private static Basket Basket { get; set; }

        public BasketController()
        {
            Basket = new Basket();
        }
        public IActionResult Index(int id)
        {           
           var product = new DataStorage().GetProductDataFromXML()
                                           .Where(p => p.Id == id)
                                          .FirstOrDefault();            
                      
            if (product == null)
            {               
                return View(Basket);
            }

            Basket.AddToBasket(product, 1);
            return View(Basket);
        }
    }
}
