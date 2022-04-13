using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface ICartsStorage
    {
        Cart TryGetByUserId(string userId);

        void Add(Product product, string userId);
    }
}
