using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class CartRepository : ICartRepository
    {
        private static List<Cart> carts = new List<Cart>();

        public static Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        public static void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart==null)
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

                carts.Add(newCart);
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
    }

    public interface ICartRepository
    {
        private static List<Cart> carts { get; set; }
        public static Cart TryGetByUserId() { return carts.FirstOrDefault(); }
        public static void Add() { }
    }
}
