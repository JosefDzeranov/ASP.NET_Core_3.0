using System;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductStorage
    {
        List<Product> GetProductData();
        Product TryGetProduct(Guid id);
        IEnumerable<Product> SearchByName(string name);
        void Add(Product product);
        void Edit(Product product);
        void Remove(Guid id);
    }
}
