using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IProductsStorage
    {
        public List<Product> GetAll();
        
        Product TryGetProduct(int id);
        
        public List<Product> DeserializeJsonProducts();


    }
}
