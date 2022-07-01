using System;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly IFavoritesStorage _favoritesStorage;
        private readonly UserManager<User> _userManager;

        public FavoritesController(IProductStorage productStorage, IFavoritesStorage favoritesStorage, UserManager<User> userManager)
        {
            _productStorage = productStorage;
            _favoritesStorage = favoritesStorage;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            var userId = GetUserId();
            var favoriteProducts= _favoritesStorage.GetAllByUserId(userId);
            if (favoriteProducts == null || favoriteProducts.Count == 0)
            {
                return View("Empty");
            }
            return View(favoriteProducts.ToProductViewModels(currentCulture));
        }

        public IActionResult Add(Guid id)
        {
            var userId = GetUserId();
            var product = _productStorage.TryGetProduct(id);
            _favoritesStorage.Add(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var userId = GetUserId();
            var product = _productStorage.TryGetProduct(id);
            _favoritesStorage.Remove(userId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var userId = GetUserId();
            _favoritesStorage.Clear(userId);
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