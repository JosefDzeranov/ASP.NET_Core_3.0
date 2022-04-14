using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IFavorites
    {
        List<Product> GetAll();

        void Add(Product product);
    }
}
