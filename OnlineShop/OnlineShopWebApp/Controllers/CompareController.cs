using System;
using Microsoft.AspNetCore.Authorization;
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
            var userId = HttpContext.Request.Cookies["userId"];
            var compareProducts = _compareStorage.GetAllByUserId(userId);
            if (compareProducts == null || compareProducts.Count == 0)
            {
                return View("Empty");
            }
            return View(compareProducts);
        }

        public IActionResult Add(Guid id)
        {
            var userId = HttpContext.Request.Cookies["userId"];
            var product = _productStorage.TryGetProduct(id);
            _compareStorage.Add(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var userId = HttpContext.Request.Cookies["userId"];
            var product = _productStorage.TryGetProduct(id);
            _compareStorage.Remove(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var userId = HttpContext.Request.Cookies["userId"];
            _compareStorage.Clear(userId);
            return RedirectToAction("Index");
        }
    }
}
