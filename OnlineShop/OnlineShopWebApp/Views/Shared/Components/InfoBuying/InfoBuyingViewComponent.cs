using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;


namespace OnlineShopWebApp.Views.Shared.Components.InfoBuying
{
    // Бланк для заполнения данных покупателя для оформления заказа
    public class InfoBuyingViewComponent:ViewComponent
    {
        private readonly IBuyerManager buyerManager;
        private readonly IUserManager userManager;

        public InfoBuyingViewComponent(IBuyerManager buyerManager, IUserManager userManager)
        {
            this.buyerManager = buyerManager;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var buyerLogin = userManager.GetLoginAuthorizedUser();
            var infoBuying = buyerManager.FindBuyer(buyerLogin).InfoBuying;
            return View("InfoBuying", infoBuying);
        }
    }
}
