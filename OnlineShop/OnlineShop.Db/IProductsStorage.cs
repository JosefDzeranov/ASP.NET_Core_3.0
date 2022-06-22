using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IProductsStorage
    {
        List<Product> GetAll();

        Product TryGetProduct(Guid id);

        void Delete(Guid Id);

        void SaveEditedProduct(Product newProduct);

        void Add(Product product);
    }
}
