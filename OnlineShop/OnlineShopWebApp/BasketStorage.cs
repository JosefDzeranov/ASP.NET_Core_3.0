using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class BasketStorage: IBasketStorage
    {
        private List<Basket> baskets = new List<Basket>();

        public List<Basket> Baskets
        {
            get 
            {
                return baskets;
            }
        }

        public Basket TryGetByUserId(string userId)
        {
            return baskets.FirstOrDefault(b => b.UserId == userId);
        }

        public void AddProduct(string userId, Product product)
        {
            var basket = TryGetByUserId(userId);

            if(basket == null)
            {
                var newBasket = new Basket(userId);
                newBasket.Items.Add(new BasketItem(product));
                baskets.Add(newBasket);
            }
            else
            {
                var basketItem = basket.Items.FirstOrDefault(item => item.Product.Id == product.Id);
                if(basketItem != null)
                {
                    basketItem.Quantity++;
                }
                else 
                {
                    basket.Items.Add(new BasketItem(product));
                }
            }
        }

        public void RemoveProduct(string userId, Product product)
        {
            var basket = TryGetByUserId(userId);

            if(basket != null)
            {
                var basketItem = basket.Items.FirstOrDefault(item => item.Product.Id == product.Id);
                
                if (basketItem != null)
                {
                    basketItem.Quantity--;
                    if (basketItem.Quantity == 0)
                    {
                        basket.Items.Remove(basketItem);
                    }
                }
            }
        }
        public void ClearBasket(string userId)
        {
            var basket = TryGetByUserId(userId);
            basket.Items.Clear();
        }
    }
}
