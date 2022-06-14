using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.CalcFavoriteProductCount
{
    public class CalcFavoriteProductCountViewComponent : ViewComponent
    {
        private readonly IFavoriteManager _favoriteManager;
        private readonly IUsersManager usersManager;
        public CalcFavoriteProductCountViewComponent(IFavoriteManager favoriteManager, IUsersManager usersManager)
        {
            _favoriteManager = favoriteManager;
            this.usersManager = usersManager;
        }

        public IViewComponentResult Invoke()
        {
            var buyerLogin = usersManager.GetLoginAuthorizedUser();
            int productCount;
            if (buyerLogin == null)
            {
                productCount = 0;
            }
            else
            {
                productCount = _favoriteManager.GetAll(buyerLogin).Count;
            }
            return View("CalcFavoriteProductCount",productCount);
        }
    }
}