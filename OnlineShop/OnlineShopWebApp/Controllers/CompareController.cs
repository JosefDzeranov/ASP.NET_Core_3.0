using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

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
            var compareProducts = _compareStorage.GetAllByUserId(Constants.UserId);
            if (compareProducts == null || compareProducts.Count == 0)
            {
                return View("Empty");
            }
            return View(compareProducts);
        }

        public IActionResult Add(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            _compareStorage.Add(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var product = _productStorage.TryGetProduct(id);
            _compareStorage.Remove(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _compareStorage.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
