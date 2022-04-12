﻿using OnlineShopWebApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class CartsStorage : ICartsStorage
    {
        private List<Cart> carts { get; set; } = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
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
                            ItemId = Guid.NewGuid(),
                            Count = 1,
                            Product = product
                        }
                    }
                };
                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);

                if (existingCartItem != null)
                {
                    existingCartItem.Count += 1; ;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        ItemId = Guid.NewGuid(),
                        Count = 1,
                        Product = product
                    });
                }
            }
        }

        public void RemoveProduct(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                carts.Remove(existingCart);
            }
        }

        public void RemoveCountProductCart(Product product, string userId)
        {
            if (carts.Count > 0)
            {
                
                if (carts.Count == 1)
                    RemoveProduct(product, userId);
                else
                    carts.RemoveAt(1);
            }
        } 

        public void RemoveAll()
        {
            carts.Clear();
        }
    }
}
