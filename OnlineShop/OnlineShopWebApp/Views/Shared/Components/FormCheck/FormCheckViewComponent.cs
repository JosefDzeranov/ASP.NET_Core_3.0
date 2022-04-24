using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

// Форма, которая заполняется перед оформлением
namespace OnlineShopWebApp.Views.Shared.Components.FormCheck
{
    public class FormCheckViewComponent : ViewComponent
    {
        private readonly IBuyerStorage buyerStorage;

        public FormCheckViewComponent(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }

        public IViewComponentResult Invoke(List<CartItem> cart)
        {
            return View("FormCheck", cart);
        }
    }
}
