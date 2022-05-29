
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db


{
    public interface ICartManager
    {
        
        List<Cart> GetCarts();

        void AddProductToCart(string userId, Product product);

        Cart TryGetCartByUserID(string userId);

        void RemoveProductFromCart(string userId, Guid productId);
        void RemoveCartLines(Cart cart);
        void Clear(string userId);

    }
}
