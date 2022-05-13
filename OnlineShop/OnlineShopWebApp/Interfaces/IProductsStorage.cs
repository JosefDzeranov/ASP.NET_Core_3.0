using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IProductsStorage
    {
        List<Product> GetAllFirst();

        List<Product> GetAll();

        Product TryGet(int id);

        List<Product> DeserializeJsonProducts();

        void Delete(int Id);

        void Edit(Product newProduct);

        void Add(Product product);
    }
}
