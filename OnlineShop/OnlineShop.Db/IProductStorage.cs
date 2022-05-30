using System;
using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IProductStorage
    {
        List<Product> GetAll();
        List<Product> GetAllAvailable();
        Product TryGetProduct(Guid id);
        IEnumerable<Product> SearchByName(string name);
        void Add(Product product);
        void Edit(Product product);
        void Remove(Guid id);
    }
}
