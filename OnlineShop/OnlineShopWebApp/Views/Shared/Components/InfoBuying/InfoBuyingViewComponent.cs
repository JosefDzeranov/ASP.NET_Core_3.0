using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.InfoBuying
{
    // Бланк для заполнения данных покупателя для оформления заказа
    public class InfoBuyingViewComponent:ViewComponent
    {
        private readonly IBuyerStorage buyerStorage;

        public InfoBuyingViewComponent(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }

        public IViewComponentResult Invoke(Guid buyerId)
        {
            buyerId = MyConstant.ValidNullBuyerId(buyerId);
            var infoBuying = buyerStorage.FindBuyer(buyerId).infoBuying;
            return View("InfoBuying", infoBuying);
        }
    }
}
