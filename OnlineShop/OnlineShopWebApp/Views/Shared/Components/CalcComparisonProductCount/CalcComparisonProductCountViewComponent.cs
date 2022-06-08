using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.CalcComparisonProductCount
{
    public class CalcComparisonProductCountViewComponent : ViewComponent
    {
        private readonly IComparisonRepository _comparisonRepository;
        private readonly IBuyerManager _buyerManager;
        private readonly IUserManager _userManager;
        public CalcComparisonProductCountViewComponent(IComparisonRepository comparisonRepository, IBuyerManager buyerManager, IUserManager userManager)
        {
            _buyerManager = buyerManager;
            _userManager = userManager;
            _comparisonRepository = comparisonRepository;
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
                productCount = _comparisonRepository.GetAll(user.Login).Count;
            }
            return View("CalcComparisonProductCount", productCount);
        }
    }
}