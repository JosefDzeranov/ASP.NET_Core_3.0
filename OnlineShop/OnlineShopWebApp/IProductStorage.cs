using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductStorage
    {
        IEnumerable<Product> GetProductData();
        Product TryGetProduct(int id);

    }
}
