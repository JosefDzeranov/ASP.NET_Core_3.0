using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;


namespace OnlineShop.Db
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(Guid id);
        List<Product> TryGetByName(string name);
        void Add(Product product);
        void Edit();
        void Delete(Guid id);
    }
}