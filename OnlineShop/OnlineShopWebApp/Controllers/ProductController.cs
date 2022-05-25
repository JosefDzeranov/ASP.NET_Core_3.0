using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productRepository;

        public ProductController(IProductsRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(int id)
        {
            var product = productRepository.TryGetByid(id);
            return View(product);
        }
    }
}
