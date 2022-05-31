using OnlineShop.DB.Models;
using System.Collections.Generic;

namespace OnlineShop.DB
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