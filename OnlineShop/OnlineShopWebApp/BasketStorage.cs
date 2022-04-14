using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class BasketStorage: IBasketStorage
    {
        private List<Basket> baskets = new List<Basket>();

        public Basket TryGetByUserId(string userId)
        {
            return baskets.FirstOrDefault(b => b.UserId == userId);
        }

        public void AddProduct(Product product, string userId)
        {
            var basket = TryGetByUserId(userId);

            if(basket == null)
            {
                var newBasket = new Basket(userId);

            }
            var basket = baskets.FirstOrDefault(b => b.Product.Id == product.Id);
                                             
            if (basketItem == null)
            {
                basket.Add(new BasketItem(product));
            }
            else
            {
                basketItem.Quantity++;
            }
        }

        public void RemoveProduct(Product product, string userId)
        {
            var basketItem = Basket.FirstOrDefault(b => b.Product.Id == product.Id);

            if (basketItem != null)           
            {
                basketItem.Quantity--;
                if(basketItem.Quantity == 0)
                {
                    Basket.Remove(basketItem);
                }
            }
        }
        public void ClearBasket(string userId)
        {
            Basket.Clear();
        }
        public decimal GetTotalSum()
        {
            return Basket.Sum(b => b.Product.Cost * b.Quantity);
        }
    }
}
