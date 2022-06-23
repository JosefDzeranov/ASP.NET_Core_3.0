using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly IBasketStorage _basketStorage;
        private readonly UserManager<User> _userManager;

        public BasketController(IProductStorage productStorage, IBasketStorage basketStorage, UserManager<User> userManager)
        {
            _productStorage = productStorage;
            _basketStorage = basketStorage;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = GetUserId();
            var basket = _basketStorage.TryGetByUserId(userId);

            if (basket == null || basket.Items.Count == 0)
            {
                return View("Empty");
            }

            var basketViewModel = basket.ToBasketViewModel();

            return View(basketViewModel);
        }

        public IActionResult Add(Guid id)
        {
            var userId = GetUserId();
            var product = _productStorage.TryGetProduct(id);
            _basketStorage.Add(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var userId = GetUserId();
            var product = _productStorage.TryGetProduct(id);
            _basketStorage.Remove(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var userId = GetUserId();
            _basketStorage.Clear(userId);
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
