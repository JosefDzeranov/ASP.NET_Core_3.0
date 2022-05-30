using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class BasketDbStorage : IBasketStorage
    {
        private readonly DatabaseContext _databaseContext;

        public BasketDbStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Basket TryGetByUserId(string userId)
        {
            var basket = _databaseContext.Baskets.Include(basket => basket.Items)
                                                 .ThenInclude(item => item.Product)
                                                 .FirstOrDefault(basket => basket.UserId == userId);
            return basket;
        }

        public void Add(string userId, Product product)
        {
            var basket = TryGetByUserId(userId);

            if (basket == null)
            {
                var newBasket = new Basket
                {
                    UserId = userId
                };

                newBasket.Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = product,
                        Quantity = 1
                    }
                };
                _databaseContext.Baskets.Add(newBasket);
            }

            else
            {
                var basketItem = basket.Items.FirstOrDefault(item => item.Product.Id == product.Id);
                if (basketItem != null)
                {
                    basketItem.Quantity++;
                }
                else
                {
                    basket.Items.Add(new BasketItem
                    {
                        Product = product,
                        Quantity = 1
                    });
                }
            }
            _databaseContext.SaveChanges();
        }

        public void Remove(string userId, Product product)
        {
            var basket = TryGetByUserId(userId);

            if (basket != null)
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
            _databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var basket = TryGetByUserId(userId);
            _databaseContext.Baskets.Remove(basket);
            _databaseContext.SaveChanges();
        }
    }
}
