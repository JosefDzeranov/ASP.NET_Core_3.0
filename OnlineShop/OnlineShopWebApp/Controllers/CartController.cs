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
            var cart = CartsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetByid(productId);
            CartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index"); 
        }
    }
}
