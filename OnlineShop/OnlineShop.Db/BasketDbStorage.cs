using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class BasketDbStorage: IBasketStorage
    {
        private readonly DatabaseContext _databaseContext;

        public BasketDbStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        //private List<Basket> baskets = new List<Basket>();

        public Basket TryGetByUserId(string userId)
        {
            return _databaseContext.Baskets.FirstOrDefault(b => b.UserId == userId);
        }

        public void AddProduct(string userId, Product product)
        {
            var basket = TryGetByUserId(userId);

            if(basket == null)
            {
                _databaseContext.Baskets.Add(basket);
                _databaseContext.SaveChanges();

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
                    basket.Items.Add(new Basket(product));
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
