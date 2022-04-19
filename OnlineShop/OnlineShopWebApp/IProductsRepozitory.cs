using OnlineShopWebApp.Models;
using System.Collections.Generic;


namespace OnlineShopWebApp
{
    public interface IProductsRepozitory
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        void AddToCompare(Product product);
        List<Product> Compare();
        void ClearCompare();
        void DeleteComparingProduct(Product product);
    }
}