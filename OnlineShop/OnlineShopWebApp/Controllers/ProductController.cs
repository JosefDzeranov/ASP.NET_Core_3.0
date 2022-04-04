using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsStorage storageProducts;

        public ProductController()
        {
            storageProducts = new ProductsStorage();
        }

        //public string Index(int id)
        //{
        //    var requestedProduct = StorageProducts.TryGetProduct(id);

        //    if (requestedProduct != null && ((requestedProduct.Id.Equals(1) || requestedProduct.Id.Equals(2) || requestedProduct.Id.Equals(3) || requestedProduct.Id.Equals(4) || requestedProduct.Id.Equals(5))))
        //        return $"{requestedProduct.Id}\r\n{requestedProduct.Name}\r\n{requestedProduct.Cost}\r\n{requestedProduct.Description}";
        //    else
        //        return "Такой услуги нет в списке, введите корректное значение 1-5";
        //}

        public IActionResult Index(int id)
        {
            var requestedProduct = ProductsStorage.TryGetProduct(id);

            //if (requestedProduct != null && ((requestedProduct.Id.Equals(1) || requestedProduct.Id.Equals(2) || requestedProduct.Id.Equals(3) || requestedProduct.Id.Equals(4) || requestedProduct.Id.Equals(5))))
            //    return $"{requestedProduct.Id}\r\n{requestedProduct.Name}\r\n{requestedProduct.Cost}\r\n{requestedProduct.Description}";
            //else
            //    return "Такой услуги нет в списке, введите корректное значение 1-5";
            return View(requestedProduct);
        }
    }
}
