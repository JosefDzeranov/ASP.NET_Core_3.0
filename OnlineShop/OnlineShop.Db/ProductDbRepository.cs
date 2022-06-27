using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductDbRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ProductDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Product Find(Guid id)
        {
            return _databaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Delete(Product product)
        {
            _databaseContext.Products.Remove(product);
            Save();
        }
        public void UpdateProduct(Product newProduct)
        {
            var oldProduct = _databaseContext.Products.FirstOrDefault(product => product.Id == newProduct.Id);

            oldProduct.Cost = newProduct.Cost;
            oldProduct.Description = newProduct.Description;
            oldProduct.Images = newProduct.Images;
            oldProduct.Length = newProduct.Length;
            oldProduct.CodeNumber = newProduct.CodeNumber;
            oldProduct.Square = newProduct.Square;
            oldProduct.Width = newProduct.Width;
            Save();
        }
        public void AddNew(Product product)
        {
            _databaseContext.Products.Add(product);
            Save();
        }

        public List<Product> GetAll()
        {
            return _databaseContext.Products.ToList();
        }

        private void Save()
        {
            _databaseContext.SaveChanges();
        }
    }
}
