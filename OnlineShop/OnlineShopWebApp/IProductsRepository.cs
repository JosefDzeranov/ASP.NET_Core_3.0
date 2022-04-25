using OnlineShopWebApp.Models;
using System.Collections.Generic;


namespace OnlineShopWebApp
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        void Add(Product product);
        void Edit(Product newProduct);
        void Delete(int id);
    }
}