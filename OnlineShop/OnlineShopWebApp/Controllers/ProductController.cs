using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductReposititory productReposititory;

        public ProductController()
        {
            productReposititory = new ProductReposititory();
        }
         
        public IActionResult Item(int id)
        {
            var product = productReposititory.TryGetById(id);
            return View(product);
           
        }
    }
}
