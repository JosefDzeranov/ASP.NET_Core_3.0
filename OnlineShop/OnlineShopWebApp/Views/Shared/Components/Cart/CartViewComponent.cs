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

        public IViewComponentResult Invoke(string userLogin)
        {
            int sumProduct;
            if (buyerManager.FindBuyer(userLogin) == null)
            {
                sumProduct = 0;
            }
            else
            {
                sumProduct = buyerManager.FindBuyer(userLogin).SumAllProducts();
            }
            return View("Cart", sumProduct);
        }
        
    }
}
