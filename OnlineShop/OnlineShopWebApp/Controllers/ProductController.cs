using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {


        public IActionResult Index(int id)
        {
            var foundProduct = ProductManager.FindProduct(id);
            return View(foundProduct);


        }



    }
}
