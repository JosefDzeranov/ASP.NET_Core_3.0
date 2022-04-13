using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public static class CartsRepozitory
    {
        private static List<Cart> carts = new List<Cart>();

        internal static Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x=>x.UserId==userId);
        }

        internal static void Add(Product product, string userId)
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
                            Id = Guid.NewGuid(),
                            Amount =1,
                            Product = product
                        }
                    }

                };

                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if(existingCartItem!=null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1,
                        Product = product
                    });
                }

            }
        }
    }
}
