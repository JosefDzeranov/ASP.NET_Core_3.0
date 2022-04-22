using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent:ViewComponent
    {
        private readonly IBuyerStorage buyerStorage;

        public CartViewComponent(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }

        public IViewComponentResult Invoke(int buyerId)
        {
            var sumProduct = buyerStorage.FindBuyer(buyerId).SumAllProducts();
            return View("Cart", sumProduct);
        }
    }
}
