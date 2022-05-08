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
        public IActionResult Item(int productId)
        {
            var product = productReposititory.TryGetById(productId);
            return View(product);
        }
        public IActionResult Items()
        {
            var products = productReposititory.GetAll();
            return View(products);
        }
    }
}
