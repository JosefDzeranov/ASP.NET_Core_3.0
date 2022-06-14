using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.CalcComparisonProductCount
{
    public class CalcComparisonProductCountViewComponent : ViewComponent
    {
        private readonly IComparisonManager _comparisonManager;
        private readonly IUsersManager usersManager;
        public CalcComparisonProductCountViewComponent(IComparisonManager comparisonManager, IUsersManager usersManager)
        {
            this.usersManager = usersManager;
            _comparisonManager = comparisonManager;
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
                productCount = _comparisonManager.GetAll(buyerLogin).Count;
            }
            return View("CalcComparisonProductCount", productCount);
        }
    }
}