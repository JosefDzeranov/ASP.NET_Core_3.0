using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductsRepository
    {
        void Add(Product product);
        void Clear(int id);
        void Edit(Product newProduct);
        List<Product> GetAllProducts();
        Product TryGetByid(int id);
        //void Remove(string roleName);
    }
}