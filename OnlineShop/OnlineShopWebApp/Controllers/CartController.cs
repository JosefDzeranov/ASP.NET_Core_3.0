using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductRepository productRepository;

        public CartController()
        {
            productRepository = new ProductRepository();
        }

        public IActionResult Index()
        {

             return View();
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetByid(productId);
            return View(product);
        }
    }
}
