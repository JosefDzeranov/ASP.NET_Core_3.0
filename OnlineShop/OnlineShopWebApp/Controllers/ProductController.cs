using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsReposititory productReposititory;

        public ProductController()
        {
            productReposititory = new ProductsReposititory();
        }
         
        public IActionResult Item(int id)
        {
            var product = productReposititory.TryGetById(id);
            return View(product);
        }
    }
}
