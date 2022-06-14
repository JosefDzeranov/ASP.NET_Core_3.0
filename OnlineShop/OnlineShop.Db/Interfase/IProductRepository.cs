using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfase
{
    public interface IProductRepository
    {
        Product Find(Guid productId);
        void Delete(Product product);
        void UpdateProduct(Product product);
        void AddNew(Product product);
        List<Product> GetAll();
    }
}
