using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Services

{
    public class CartRepository : ICartRepository
    {
        private List<Cart> сarts = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            return сarts.FirstOrDefault(x => x.UserId == userId);
        }

        //public void Add(Product product, string userId)
        //{
        //    var existingCart = TryGetByUserId(userId);
        //    if (existingCart == null)
        //    {
        //        var newCart = new Cart
        //        {
        //            Id = Guid.NewGuid(),
        //            UserId = userId,
        //            Items = new List<CartItem>
        //            {
        //                new CartItem
        //                {
        //                    Id = Guid.NewGuid(),
        //                    Product = product,
        //                    Quantinity = 1
        //                }
        //            }
        //        };
        //        сarts.Add(newCart);
        //    }
        //    else
        //    {
        //        var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
        //        if (existingCartItem != null)
        //        {
        //            existingCartItem.Quantinity += 1;
        //        }
        //        else
        //        {
        //            existingCart.Items.Add(new CartItem
        //            {
        //                Id = Guid.NewGuid(),
        //                Product = product,
        //                Quantinity = 1
        //            });

        //        }
        //    }

        //}

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart != null)
            {
                сarts.Remove(existingCart);
            }

        }

        public void RemoveItem(ProductViewModel product, string userId)
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
                сarts.Remove(existingCart);
            }
        }


    }
}
