using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productReposititory;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productReposititory = productsRepository;
        }
         
        public IActionResult Item(int id)
        {
            var product = productReposititory.TryGetById(id);
            return View(product);
        }
    }
}
