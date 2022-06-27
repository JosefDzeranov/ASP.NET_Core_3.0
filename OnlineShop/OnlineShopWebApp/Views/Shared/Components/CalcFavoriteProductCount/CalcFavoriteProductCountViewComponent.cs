using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.CalcFavoriteProductCount
{
    public class CalcFavoriteProductCountViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IUsersManager usersManager;
        public CalcFavoriteProductCountViewComponent(IFavoriteRepository favoriteRepository, IUsersManager usersManager)
        {
            _favoriteRepository = favoriteRepository;
            this.usersManager = usersManager;
        }

        public IViewComponentResult Invoke()
        {
            var buyerLogin = usersManager?.GetLoginAuthorizedUser();
            int productCount;
            if (buyerLogin == null)
            {
                productCount = 0;
            }
            else
            {
                productCount = _favoriteRepository.GetAll(buyerLogin).Count;
            }
            return View("CalcFavoriteProductCount",productCount);
        }
    }
}