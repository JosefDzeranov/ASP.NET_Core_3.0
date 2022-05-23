using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IProductManager
    {
        List<Product> Products { get; set; }
        Product Find(Guid productId);
        void Delete(Product product);
        void UpdateProduct(Product product);
        void AddNew(Product product);
    }
}
