using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IProductBase
    {
        IEnumerable<Product> AllProducts();
    }
}