﻿using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB.Services

{
    public class CartRepository : ICartRepository
    {
        private readonly OnlineShopContext onlineShopContext;

        public CartRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return onlineShopContext.Carts.FirstOrDefault(x => x.UserId == userId);
        }
        public Cart TryGetById(Guid Id)
        {
            return onlineShopContext.Carts.FirstOrDefault(x => x.Id == Id);
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
                onlineShopContext.Carts.Add(newCart);

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
                    var carItem = new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        Quantinity = 1

                    };
                    onlineShopContext.CartItems.Add(carItem);
                    existingCart.Items.Add(carItem);

                }
                onlineShopContext.Carts.Update(existingCart);
            }

            onlineShopContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                onlineShopContext.Carts.Remove(existingCart);
                onlineShopContext.SaveChanges();
            }

        }

        public void RemoveItem(Guid productId, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == productId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantinity -= 1;
                    if (existingCartItem.Quantinity == 0)
                    {
                        existingCart.Items.Remove(existingCartItem);
                    }
                    onlineShopContext.Carts.Update(existingCart);
                    onlineShopContext.SaveChanges();
                }
            }
            if (existingCart.Items.Count == 0)
            {
                onlineShopContext.Carts.Remove(existingCart);
                onlineShopContext.SaveChanges();
            }
        }

        public bool UpdateUserId(string tempUserId, string userId)
        {
            var existingCart = TryGetByUserId(tempUserId);
            if(existingCart != null)
            {
                existingCart.UserId = userId;
                onlineShopContext.Carts.Update(existingCart);
                onlineShopContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
