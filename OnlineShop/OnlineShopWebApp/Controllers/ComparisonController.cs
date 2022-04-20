using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ComparisonController : Controller
    {
        private readonly IProductsRepository productRepository;
        private readonly IComparisonRepository comparisonRepository;

        public ComparisonController(IProductsRepository productRepository, IComparisonRepository comparisonRepository)
        {
            this.productRepository = productRepository;
            this.comparisonRepository = comparisonRepository;
        }

        public IActionResult Compare()
        {
            return View();
        }

        public IActionResult Add(int productId)
        {
            var product = productRepository.TryGetByid(productId);
            comparisonRepository.Add(product, Constants.UserId);
            return RedirectToAction("Compare");
        }
    }
}