using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private IProductStorage ProductStorage { get; }
        private ICompareStorage CompareStorage { get; }

        public CompareController(IProductStorage productStorage, ICompareStorage compareStorage)
        {
            ProductStorage = productStorage;
            CompareStorage = compareStorage;
        }
        public IActionResult Index()
        {
            var compareBasket = CompareStorage.TryGetByUserId(Constants.UserId);
            if (compareBasket == null || compareBasket.Items.Count == 0)
            {
                return View("Empty");
            }
            return View(compareBasket);
        }

        public IActionResult Add(int id)
        {
            var product = ProductStorage.TryGetProduct(id);
            CompareStorage.AddProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = ProductStorage.TryGetProduct(id);
            CompareStorage.RemoveProduct(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            CompareStorage.ClearBasket(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
