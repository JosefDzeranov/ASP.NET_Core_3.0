using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductDbStorage : IProductStorage
    {
        private readonly DatabaseContext _databaseContext;

        public ProductDbStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Product> GetProductData()
        {
            return _databaseContext.Products.ToList();
        }

        public Product TryGetProduct(Guid id)
        {
            var product = _databaseContext.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            var products = _databaseContext.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            return products;
        }
        public void Add(Product product)
        {
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
        }

        public void Edit(Product product)
        {
            var editProduct = _databaseContext.Products.FirstOrDefault(p => p.Id == product.Id);

            if(editProduct == null)
            {
                return;
            }

            editProduct.ImagePath = product.ImagePath;
            editProduct.Name = product.Name;
            editProduct.Cost = product.Cost;
            editProduct.Description = product.Description;

            _databaseContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var product = _databaseContext.Products.FirstOrDefault(p => p.Id == id);
            _databaseContext.Products.Remove(product);
            _databaseContext.SaveChanges();
        }
    }
}
