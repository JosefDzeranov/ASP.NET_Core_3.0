using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfase;


namespace OnlineShopWebApp.Views.Shared.Components.InfoBuying
{
    // Бланк для заполнения данных покупателя для оформления заказа
    public class InfoBuyingViewComponent:ViewComponent
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IUsersManager usersManager;

        public InfoBuyingViewComponent(IUsersManager usersManager, ICartsRepository cartsRepository)
        {
            this.usersManager = usersManager;
            _cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var buyerLogin = usersManager.GetLoginAuthorizedUser();
            var infoBuying = _cartsRepository.Find(buyerLogin).UserDeleveryInfo;

            return View("InfoBuying", Mapping.ToUserDeleveryInfo_ViewModels(infoBuying));
        }
    }
}
