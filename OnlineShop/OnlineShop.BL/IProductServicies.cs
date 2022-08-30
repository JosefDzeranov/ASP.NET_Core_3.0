using Domains;
using System.Collections.Generic;

namespace OnlineShop.BL
{
    public interface IProductServicies
    {
        IEnumerable<Product> AllProducts();
        void Add(Product product);
        void Delete(int productId);
        void Edit(Product product);
        Product TryGetById(int productId);
    }
}
