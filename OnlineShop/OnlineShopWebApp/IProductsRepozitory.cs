using OnlineShopWebApp.Models;
using System.Collections.Generic;


namespace OnlineShopWebApp
{
    public interface IProductsRepozitory
    {
        List<Product> GetAll();
        Product TryGetById(int id);
    }
}