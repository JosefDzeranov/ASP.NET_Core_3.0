    using Entities;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB
{
    public class ProductsDBRepository : IProductBase
    {
        private readonly DatabaseContext _databaseContext;

        public ProductsDBRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<ProductEntity> AllProducts()
        {
            return _databaseContext.Products.AsNoTracking();
        }

        public ProductEntity TryGetById(int productId)
        {
            return _databaseContext.Products.FirstOrDefault(x => x.Id == productId);
        }

        public void Add(ProductEntity ProductEntity)
        {
            ProductEntity.ImgPath = "/img/Silk_green.jpg";
            _databaseContext.Products.Add(ProductEntity);
            _databaseContext.SaveChanges();
        }

        public void Delete(int productId)
        {
            _databaseContext.Products.Remove(TryGetById(productId));
            _databaseContext.SaveChanges();
        }

        public void Edit(ProductEntity ProductEntity)
        {
            var existingProduct = AllProducts().FirstOrDefault(x => x.Id == ProductEntity.Id);
            existingProduct.Name = ProductEntity.Name;
            existingProduct.Description = ProductEntity.Description;
            existingProduct.Cost = ProductEntity.Cost;
            existingProduct.ImgPath = "/img/Silk_green.jpg";
            _databaseContext.SaveChanges();
        }
    }
}
