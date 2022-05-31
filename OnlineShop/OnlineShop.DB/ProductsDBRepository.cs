using OnlineShop.Db;
using OnlineShop.DB.Models;
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

        public int NextproductId()
        {
            if(AllProducts().Any())
            {
                var maxIdProduct = AllProducts().Select(x => x.Id).Max();
                return maxIdProduct + 1;
            }
            else
            {
                return 1;
            }
        }
        public IEnumerable<Product> AllProducts()
        {
            return _databaseContext.Products;
        }

        public Product TryGetById(int productId)
        {
            return AllProducts().FirstOrDefault(x => x.Id == productId);
        }

        public void Add(Product product)
        {
            product.ImgPath = "/img/Silk_green.jpg";
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
        }

        public void Delete(int productId)
        {
            _databaseContext.Products.Remove(TryGetById(productId));
            _databaseContext.SaveChanges();
        }

        public void Edit(Product Product)
        {
            var existingProduct = AllProducts().FirstOrDefault(x => x.Id == Product.Id);
            existingProduct.Name = Product.Name;
            existingProduct.Description = Product.Description;
            existingProduct.Cost = Product.Cost;
            existingProduct.ImgPath = "/img/Silk_green.jpg";
            _databaseContext.SaveChanges();
        }
    }
}
