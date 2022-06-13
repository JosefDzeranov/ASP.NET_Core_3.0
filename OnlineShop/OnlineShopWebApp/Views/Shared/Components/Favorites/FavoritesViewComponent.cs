using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Views.Shared.Components.Favorites
{
    public class FavoritesViewComponent : ViewComponent
    {
        public readonly IFavoriteRepository favoriteRepository;
        private readonly UserManager<User> userManager;
        public FavoritesViewComponent(IFavoriteRepository favoriteRepository, UserManager<User> userManager)
        {
            this.favoriteRepository = favoriteRepository;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var favorites = favoriteRepository.TryGetByUserId(userId);
            var productCount = favorites?.Products.Count ?? (0);
            return View("Favorites", productCount);
        }
    }
}
