using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface ICartManager
    {
        Cart CreateCart();
        List<Cart> GetCarts();

        void AddProductToCart(string userId, ProductViewModel product);

        Cart TryGetCartByUserID(string userId);

        void RemoveProductFromCart(string userId, Guid productId);
        void RemoveCartLines(Cart cart);
        void Clear(string userId);

    }
}
