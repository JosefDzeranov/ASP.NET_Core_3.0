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

        public Basket TryGetByUserId(string userId)
        {
            var basket = _databaseContext.Baskets.FirstOrDefault(b => b.UserId == userId);
            return basket;
        }

        public void AddProduct(string userId, Product product)
        {
            var basket = TryGetByUserId(userId);

            if(basket == null)
            {
                _databaseContext.Baskets.Add(basket);
                _databaseContext.SaveChanges();
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
                    basket.Items.Add(basketItem);
                    _databaseContext.SaveChanges();
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
                        _databaseContext.SaveChanges();
                    }
                }
            }
        }
        public void ClearBasket(string userId)
        {
            var basket = TryGetByUserId(userId);
            basket.Items.Clear();
            _databaseContext.SaveChanges();
        }
    }
}
