using OnlineShop.Db.Models;
using System.Collections.Generic;


namespace OnlineShop.Db
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        List<Product> TryGetByName(string name);
        void Add(Product product);
        void Edit(Product newProduct);
        void Delete(int id);
    }
}