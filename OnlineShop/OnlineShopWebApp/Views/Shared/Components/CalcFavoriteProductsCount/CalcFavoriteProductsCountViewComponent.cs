using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.db.Models;
using OnlineShop.db;
using Microsoft.AspNetCore.Identity;

namespace OnlineShopWebApp.Views.Shared.Components.CalcFavoriteProductsCount
{
    public class CalcFavoriteProductsCountViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly UserManager<User> userManager;

        public CalcFavoriteProductsCountViewComponent(IFavoriteRepository favoriteRepository, UserManager<User> userManager)
        {
            this.favoriteRepository = favoriteRepository;
            this.userManager= userManager;
        }

        //public IViewComponentResult Invoke()
        //{
        //    var productsCount = favoriteRepository.GetAll(User.Identity.Name)?.Count ?? 0;
        //    return View("CalcFavoriteProductsCount", productsCount);
        //}

        public IViewComponentResult Invoke()
        {
            var productCount = 0;
            if (User.Identity.IsAuthenticated)
            {
                var userId = userManager.FindByNameAsync(User.Identity.Name).Result?.Id;
                var favorites = favoriteRepository.TryGetByUserId(userId);
                productCount = favorites?.Products.Count ?? 0;
            }
            return View("CalcFavoriteProductsCount", productCount);
        }
    }
}
    

