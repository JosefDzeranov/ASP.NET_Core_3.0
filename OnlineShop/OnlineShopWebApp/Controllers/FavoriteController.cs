using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavoriteController : Controller
    {
        private readonly IProductsStorage productStorage;
        private readonly IFavoriteStorage favoriteStorage;
        private readonly UserManager<User> userManager;

        public FavoriteController(IProductsStorage productStorage, IFavoriteStorage favoriteStorage, UserManager<User> userManager)
        {
            this.productStorage = productStorage;
            this.favoriteStorage = favoriteStorage;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var favoriteProducts = favoriteStorage.GetAllByUserId(Constants.UserId);
            if (favoriteProducts == null || favoriteProducts.Count == 0)
            {
                return View();
            }
            return View(favoriteProducts);
        }

        public IActionResult Add(Guid id)
        {
            var product = productStorage.TryGetProduct(id);
            favoriteStorage.Add(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id)
        {
            var product = productStorage.TryGetProduct(id);
            favoriteStorage.Remove(Constants.UserId, product);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            favoriteStorage.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }

        private string GetUserId()
        {
            string userId;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                userId = userManager.GetUserId(User);
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