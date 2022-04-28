using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICompareRepository compareRepository;

        public CompareController(IProductsRepository productsRepository, ICompareRepository compareRepository)
        {
            this.productsRepository = productsRepository;
            this.compareRepository = compareRepository;
        }

        public IActionResult Index()
        {
            var compareList = compareRepository.TryGetByUserId(Constants.UserId);
            if (compareList == null || compareList.Products.Count == 0)
            {
                return View("notfound");
            }
            return View(compareList);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            compareRepository.Add(product, Constants.UserId);

            return RedirectToAction("Index", "Compare");
        }

        public IActionResult Clear(int productId)
        {
            var product = productsRepository.TryGetByid(productId);
            compareRepository.Clear(product, Constants.UserId);

            return RedirectToAction("Index");
        }
    }
}
