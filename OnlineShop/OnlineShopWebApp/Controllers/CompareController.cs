using System;
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
            var compareList = _compareStorage.TryGetByUserId(Constants.UserId);
            if (compareList == null || compareList.Products.Count == 0)
            {
                return View("Empty");
            }
            return View(compareList);
        }

        public IActionResult Add(string productId)
        {
            var product = _productStorage.TryGetProduct(productId);
            _compareStorage.AddProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string productId)
        {
            var product = _productStorage.TryGetProduct(productId);
            _compareStorage.RemoveProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _compareStorage.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
