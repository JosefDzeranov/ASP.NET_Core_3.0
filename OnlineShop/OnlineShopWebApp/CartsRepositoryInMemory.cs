using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CartsRepositoryInMemory : ICartsRepository
    {
        public List<Cart> Carts { get; set; } = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            return Carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(ProductViewModel product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id=Guid.NewGuid(),
                            Amount=1,
                            Product=product
                        }
                    }
                };

                Carts.Add(newCart);
            }
            else
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
                        Id=Guid.NewGuid(),
                        Amount =1,
                        Product = product
                    });
                }
            }
        }

        public void Remove(ProductViewModel product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Amount -= 1;
            }
            if (existingCartItem.Amount==0)
            {
                existingCart.Items.Remove(existingCartItem);
            }
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            Carts.Remove(existingCart);
        }
    }
}
