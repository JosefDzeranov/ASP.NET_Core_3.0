using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {


        public string Index(int id)
        {
            var foundProduct = ProductManager.FindProduct(id);
            if (foundProduct != null)
            {
                return $"{foundProduct.Id}\n{foundProduct.Name}\n{foundProduct.Cost}\n{foundProduct.Description}";
            }
            else
            {
                return $"Продукта с Id {id} не существует";
            }
        }



    }
}
