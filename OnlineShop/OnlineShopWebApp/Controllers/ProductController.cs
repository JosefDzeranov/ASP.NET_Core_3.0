using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {


        public string Index(int id)
        {
            return ProductManager.FindProduct(id);
        }



    }
}
