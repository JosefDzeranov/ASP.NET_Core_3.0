using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
{
    public interface IProductRepository
    {
        Product TryGetById(int id);
        List<Product> GetAll();
        void Delete(Product product);
        void Add(Product product);
        void Update(Product product);
    }
}
