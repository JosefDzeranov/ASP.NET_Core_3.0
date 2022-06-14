using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;


namespace OnlineShopWebApp.Views.Shared.Components.InfoBuying
{
    // Бланк для заполнения данных покупателя для оформления заказа
    public class InfoBuyingViewComponent:ViewComponent
    {
        private readonly ICartsManager _cartsManager;
        private readonly IUsersManager usersManager;

        public InfoBuyingViewComponent(IUsersManager usersManager, ICartsManager cartsManager)
        {
            this.usersManager = usersManager;
            _cartsManager = cartsManager;
        }

        public IViewComponentResult Invoke()
        {
            var buyerLogin = usersManager.GetLoginAuthorizedUser();
            var infoBuying = _cartsManager.Find(buyerLogin).UserDeleveryInfo;
            return View("InfoBuying", infoBuying);
        }
    }
}
