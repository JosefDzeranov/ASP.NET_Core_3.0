using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        public string Index(int id)
        {
            string s = string.Empty;
            var addedProducts = BasketStorage.AddToBasket(id);
            foreach (var item in addedProducts)
            {
                s += item.Name;
            }
            return s;
        }
    }
}
