using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services

{
    public class CartBase : ICartBase
    {
        private List<Cart> Сarts { get; set; } = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            return Сarts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
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
                            Id = Guid.NewGuid(),
                            Product = product,
                            Quantinity = 1
                        }
                    }
                };
                Сarts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantinity += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        Quantinity = 1
                    });

                }
            }

        }

        public void RemoveAll(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                Сarts.Remove(existingCart);
            }

        }

        public void Remove(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantinity -= 1;
                    if (existingCartItem.Quantinity == 0)
                    {
                        existingCart.Items.Remove(existingCartItem);
                    }
                }
            }
            if (existingCart.Items.Count == 0)
            {
                Сarts.Remove(existingCart);
            }
        }


    }
}
