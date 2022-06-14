using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.CalcComparisonProductCount
{
    public class CalcComparisonProductCountViewComponent : ViewComponent
    {
        private readonly IComparisonRepository _comparisonRepository;
        private readonly IUsersManager usersManager;
        public CalcComparisonProductCountViewComponent(IComparisonRepository comparisonRepository, IUsersManager usersManager)
        {
            this.usersManager = usersManager;
            _comparisonRepository = comparisonRepository;
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
                productCount = _comparisonRepository.GetAll(buyerLogin).Count;
            }
            return View("CalcComparisonProductCount", productCount);
        }
    }
}