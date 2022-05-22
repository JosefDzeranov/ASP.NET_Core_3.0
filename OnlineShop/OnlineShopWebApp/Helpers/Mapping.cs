using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static BasketItemViewModel ToBasketItemViewModel(this BasketItem basketItem)
        {
            var basketItemViewModel = new BasketItemViewModel
            {
                Id = basketItem.Id,
                Product = basketItem.Product,
                Quantity = basketItem.Quantity
            };
            return basketItemViewModel;
        }


        public static BasketViewModel ToBasketViewModel(this Basket basket)
        {
            var items = new List<BasketItemViewModel>();

            foreach(var item in basket.Items)
            {
                items.Add(item.ToBasketItemViewModel());
            }

            var basketViewModel = new BasketViewModel
            {
                Id =basket.Id,
                UserId = basket.UserId,
                Items = items
            };

            return basketViewModel;
        }
    }
}
