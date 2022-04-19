using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Components.Basket
{
    public class BasketViewComponent: ViewComponent
    {
        private readonly IBasketStorage _basketStorage;

        public BasketViewComponent(IBasketStorage basketStorage)
        {
            _basketStorage = basketStorage;
        }

        public IViewComponentResult Invoke()
        {
            var basket = _basketStorage.TryGetByUserId(Constants.UserId);
            var productCount = basket?.TotalQuantity;
            return View("Basket", productCount);
        }
    }
}
