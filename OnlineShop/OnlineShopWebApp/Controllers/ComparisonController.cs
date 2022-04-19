using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly ICartsRepository cartsRepository;

        public ComparisonController(IProductsRepository productRepository, ICartsRepository cartsRepository)
        {
            this.productRepository = productRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Compare()
        {
            return View();
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetByid(productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Compare");
        }
    }
}
