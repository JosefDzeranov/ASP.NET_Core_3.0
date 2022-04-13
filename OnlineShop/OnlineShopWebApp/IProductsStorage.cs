using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public interface IProductsStorage
    {
        List<Product> GetAllProducts();
        Product TryGetProduct(int id);
    }
}
