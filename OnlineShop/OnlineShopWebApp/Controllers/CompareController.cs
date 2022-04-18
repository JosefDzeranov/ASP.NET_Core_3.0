using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly ICompareStorage _compareStorage;

        public CompareController(IProductStorage productStorage, ICompareStorage compareStorage)
        {
            _productStorage = productStorage;
            _compareStorage = compareStorage;
        }
        public IActionResult Index()
        {
            var compareBasket = _compareStorage.TryGetByUserId(Constants.UserId);
            if (compareBasket == null || compareBasket.Items.Count == 0)
            {
                return View("Empty");
            }
            return View(compareBasket);
        }

        public IActionResult Add(int id)
        {
            var product = _productStorage.TryGetProduct(id);
            _compareStorage.AddProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = _productStorage.TryGetProduct(id);
            _compareStorage.RemoveProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _compareStorage.ClearBasket(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
