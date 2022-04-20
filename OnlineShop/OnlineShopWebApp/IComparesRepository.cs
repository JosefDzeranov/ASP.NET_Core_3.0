using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IComparesRepository
    {
        List<Product> GetCompare();
        void Add(Product product);

        void Clear();
        void Delete(int id);

    }
}