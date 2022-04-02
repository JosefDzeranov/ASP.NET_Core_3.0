using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            if (StorageProducts.ShowProducts() == null)
                return "Такой услуги нет в списке, введите корректное значение 1-5";
            else
                return StorageProducts.ShowProducts().ToString();
        }
    }
}
