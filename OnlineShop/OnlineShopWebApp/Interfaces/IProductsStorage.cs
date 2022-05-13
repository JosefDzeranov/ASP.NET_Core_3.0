using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interface
{
    public interface IProductsStorage
    {
        List<Product> GetAll();

        Product TryGet(int id);

        void Delete(int Id);

        void Edit(Product newProduct);

        void Add(Product product);
    }
}
