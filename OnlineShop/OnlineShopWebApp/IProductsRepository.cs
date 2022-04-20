using OnlineShopWebApp.Models;
using System.Collections.Generic;


namespace OnlineShopWebApp
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(int id);
    }
}