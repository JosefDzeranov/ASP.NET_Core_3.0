using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public string Index(int id)
        {
            var requestedProduct = StorageProducts.TryGetProduct(id);
            if (requestedProduct != null)
                return "Такой услуги нет в списке, введите корректное значение 1-5";
            else
                return @"{requestedProduct.id}\r\n{requestedProduct.name}\r\n{requestedProduct.Cost}\r\n{requestedProduct.Description}";
        }
    }
}
