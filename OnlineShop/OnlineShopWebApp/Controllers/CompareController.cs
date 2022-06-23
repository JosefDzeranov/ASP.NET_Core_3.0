using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly ICompareStorage _compareStorage;
        private readonly UserManager<User> _userManager;

        public CompareController(IProductStorage productStorage, ICompareStorage compareStorage, UserManager<User> userManager)
        {
            _productStorage = productStorage;
            _compareStorage = compareStorage;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = GetUserId();
            var compareProducts = _compareStorage.GetAllByUserId(userId);
            if (compareProducts == null || compareProducts.Count == 0)
            {
                return View("Empty");
            }
            return View(compareProducts);
        }

        public IActionResult Add(Guid id)
        {
            var userId = GetUserId();
            var product = _productStorage.TryGetProduct(id);
            _compareStorage.Add(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var userId = GetUserId();
            var product = _productStorage.TryGetProduct(id);
            _compareStorage.Remove(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var userId = GetUserId();
            _compareStorage.Clear(userId);
            return RedirectToAction("Index");
        }

        private string GetUserId()
        {
            string userId;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = _userManager.GetUserId(User);
            }
            else
            {
                if (HttpContext.Request.Cookies.ContainsKey("tempUserId"))
                {
                    userId = HttpContext.Request.Cookies["tempUserId"];
                }
                else
                {
                    userId = Guid.NewGuid().ToString();
                    HttpContext.Response.Cookies.Append("tempUserId", userId);
                }
            }
            return userId;
        }
    }
}
