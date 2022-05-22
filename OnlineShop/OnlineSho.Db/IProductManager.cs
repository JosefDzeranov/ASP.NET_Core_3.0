using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Db
{
    public interface IProductManager
    {
       
        public List<Product> GetAll();
        public void AddProduct(Product product);
        public Product TryGetById(Guid id);

        public void EditProduct(Product product);

    }
}
