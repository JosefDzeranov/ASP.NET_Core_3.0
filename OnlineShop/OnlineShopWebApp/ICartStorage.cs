using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface ICartManager
    {
        Cart CreateCart();
        List<Cart> GetCarts();

        void AddProductToCart(string userId, Product product);

        Cart TryGetCartByUserID(string userId);

        void RemoveProductFromCart(string userId, Product product);
        void RemoveCartLines(Cart cart);

    }
}
