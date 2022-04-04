using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            if (StorageProducts.ShowProducts() == null)
                return "Возникла проблема в списке не оказалось услуг.";
            else
                return StorageProducts.ShowProducts();
        }
    } 
}
