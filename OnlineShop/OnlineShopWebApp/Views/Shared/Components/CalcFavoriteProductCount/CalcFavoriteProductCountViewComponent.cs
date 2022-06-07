using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.CalcFavoriteProduct
{
    public class CalcFavoriteProductCountViewComponent : ViewComponent
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IBuyerManager _buyerManager;
        private readonly IUserManager _userManager;
        public CalcFavoriteProductCountViewComponent(IFavoriteRepository favoriteRepository, IBuyerManager buyerManager, IUserManager userManager)
        {
            _favoriteRepository = favoriteRepository;
            _buyerManager = buyerManager;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = _buyerManager.FindBuyer(_userManager.GetLoginAuthorizedUser());
            int productCount;
            if (user == null)
            {
                productCount = 0;
            }
            else
            {
                productCount = _favoriteRepository.GetAll(user.Login).Count;
            }
            return View("CalcFavoriteProductCount",productCount);
        }
    }
}