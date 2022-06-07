using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.CalcFavoriteProduct
{
    public class CalcFavoriteProductCountViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository favoriteRepository;
        public CalcFavoriteProductCountViewComponent(IFavoriteRepository favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }

        public IViewComponentResult Invoke(string userLogin)
        {
            var productCount = favoriteRepository.GetAll(userLogin).Count;
            return View("CalcFavoriteProductCount",productCount);
        }
    }
}