using OnlineShop.db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{ 
    public interface IProductDataSource
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        public void RemoveProduct(int Id);
        public void EditProduct(Product product);

    }
}