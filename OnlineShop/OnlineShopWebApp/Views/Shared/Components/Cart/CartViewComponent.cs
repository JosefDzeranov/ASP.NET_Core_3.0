using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IBuyerManager buyerManager;

        public CartViewComponent(IBuyerManager buyerManager)
        {
            this.buyerManager = buyerManager;
        }

        public IViewComponentResult Invoke(Guid buyerId)
        {
            buyerId = MyConstant.DefaultBuyerIdIsNull(buyerId);
            var sumProduct = buyerManager.FindBuyer(buyerId).SumAllProducts();
            return View("Cart", sumProduct);
        }
        
    }
}
