using OnlineShopWebApp.Models;
using System.Collections.Generic;


namespace OnlineShopWebApp
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        Product TryGetByName(string name);
        void Add(Product product);
        void Edit(int id, Product newProduct);
        void Delete(int id);
    }
}