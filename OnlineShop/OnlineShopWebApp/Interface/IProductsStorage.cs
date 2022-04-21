using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IProductsStorage
    {
        List<Product> GetAll();

        Product TryGetProduct(int id);

        List<Product> DeserializeJsonProducts();


    }
}
