using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface ICartsStorage
    {
        Cart TryGetByUserId(string userId);

        void Add(Product product, string userId);

        void RemoveProduct(Product product, string userId);

        void RemoveAll();

        void RemoveCountProductCart(Product product, string userId);
    }
}
