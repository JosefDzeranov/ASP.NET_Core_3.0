using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductsRepository
    {
        List<Product> GetAllProducts();
        Product TryGetByid(int id);
    }
}