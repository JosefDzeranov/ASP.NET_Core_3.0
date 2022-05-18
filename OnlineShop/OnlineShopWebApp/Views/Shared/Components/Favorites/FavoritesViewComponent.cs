using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Services;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Views.Shared.Components.Favorites
{
    public class FavoritesViewComponent : ViewComponent
    {
        public readonly IFavoriteRepository favoriteRepository;

        public FavoritesViewComponent(IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var favorites = favoriteRepository.TryGetByUserId(Const.UserId);
            var productCount = favorites?.Products.Count ?? (0);
            return View("Favorites", productCount);
        }
    }
}
