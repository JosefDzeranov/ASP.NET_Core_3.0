using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helper;

namespace OnlineShopWebApp.Views.Shared.ViewComponents.CartViewComponents
{
    public class CalcFavoriteProductsCountViewComponent: ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;
        public CalcFavoriteProductsCountViewComponent(IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var productsCount = favoriteRepository.GetAll(Constants.UserId).Count;
            return View("FavoriteProductsCountView", productsCount);
        }
    }
}
