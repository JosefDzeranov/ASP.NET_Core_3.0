using Entities;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public interface IProductBase
    {
        IEnumerable<ProductEntity> AllProducts();
        void Add(ProductEntity product);
        void Delete(int productId);
        void Edit(ProductEntity product);
        ProductEntity TryGetById(int productId);
    }
}