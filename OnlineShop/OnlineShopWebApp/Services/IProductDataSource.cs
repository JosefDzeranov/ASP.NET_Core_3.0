using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Services
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