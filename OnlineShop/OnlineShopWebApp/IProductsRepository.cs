using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        void EditDescription(Product product);
        void Delete(Product product);
        void Add(Product product);
    }

}
