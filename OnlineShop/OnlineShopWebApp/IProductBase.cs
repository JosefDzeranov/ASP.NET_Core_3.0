using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductBase
    {
        IEnumerable<Product> AllProducts();
    }
}