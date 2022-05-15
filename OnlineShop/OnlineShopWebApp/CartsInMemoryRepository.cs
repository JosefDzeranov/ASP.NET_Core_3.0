using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CartsInMemoryRepository : ICartBase
    {
        private List<Cart> carts = new List<Cart>();

        public Cart TryGetByUserId(int userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, int userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Product = product,
                        Amount = 1,
                        Id = Guid.NewGuid()
                    });
                }
            }
            else
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Amount = 1,
                            Product = product
                        }


                    }
                };
                carts.Add(newCart);

            }

        }

        public void DecreaseAmount(int productId, int userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Product.Id == productId);
            if (existingCartItem.Amount > 0)
            {
                existingCartItem.Amount -= 1;
                if (existingCartItem.Amount == 0)
                {
                    existingCart.Items.Remove(existingCartItem);
                }
                if( !existingCart.Items.Any())
                {
                    carts.Remove(existingCart);
                }
                
            }
        }

        public void Delete(int userId)
        {
            var existingCart = TryGetByUserId(userId);
            carts.Remove(existingCart);
        }
    }
}
