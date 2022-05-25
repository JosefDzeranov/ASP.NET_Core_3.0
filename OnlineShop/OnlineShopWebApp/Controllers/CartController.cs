using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductRepository productRepository;
        private readonly CartsRepository carsRepository;

        public CartController(ProductRepository productRepository, CartsRepository carsRepository)
        {
            this.productRepository = productRepository;
            this.carsRepository = carsRepository;
        }

        public IActionResult Index()
        {
            var cart = carsRepository.TryGetByUserId(Constants.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetByid(productId);
            carsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index"); 
        }
    }
}
