using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class CartsRepository : ICartsRepository
    {
        public List<Cart> Carts { get; set; } = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            return Carts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
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
    }

    public interface ICartsRepository
    {
        private static List<Cart> carts { get; set; }
        public Cart TryGetByUserId() { return carts.FirstOrDefault(); }
        public static void Add() { }
    }
}
