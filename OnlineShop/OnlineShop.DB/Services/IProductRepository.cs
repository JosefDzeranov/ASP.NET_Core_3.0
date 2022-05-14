using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.DB.Services
{
    public interface IProductRepository
    {
        Product TryGetById(Guid id);
        List<Product> GetAll();
        void Delete(Product product);
        void Add(Product product);
        void Update(Product product);
    }
}
