using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductBase
    {
        IEnumerable<Product> AllProducts();
        void Add(Product product);
        void Delete(int productId);
        void Edit(Product product);
        Product TryGetById(int productId);
    }
}