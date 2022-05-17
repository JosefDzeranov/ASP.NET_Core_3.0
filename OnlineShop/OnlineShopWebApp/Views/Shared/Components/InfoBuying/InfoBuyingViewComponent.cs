using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Views.Shared.Components.InfoBuying
{
    // Бланк для заполнения данных покупателя для оформления заказа
    public class InfoBuyingViewComponent:ViewComponent
    {
        private readonly IBuyerManager buyerManager;

        public InfoBuyingViewComponent(IBuyerManager buyerManager)
        {
            this.buyerManager = buyerManager;
        }

        public IViewComponentResult Invoke(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            var infoBuying = buyerManager.FindBuyer(buyerId).InfoBuying;
            return View("InfoBuying", infoBuying);
        }
    }
}
