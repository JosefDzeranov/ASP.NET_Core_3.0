using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.db.Models;
using OnlineShop.db;

namespace OnlineShopWebApp.Views.Shared.Components.CalcFavoriteProductsCount
{
    public class CalcFavoriteProductsCountViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;

        public CalcFavoriteProductsCountViewComponent(IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = favoriteRepository.GetAll(Const.UserId)?.Count ?? 0;
            return View("CalcFavoriteProductsCount", productsCount);
        }
    }
}
