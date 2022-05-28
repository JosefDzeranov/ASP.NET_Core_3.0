using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductManager : IProductManager
    {
        private readonly DatabaseContext _databaseContext;
        public ProductManager(DatabaseContext databaseContext)
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
            _databaseContext.SaveChanges();
        }
        public void UpdateProduct(Product newProduct)
        {
            var oldProduct = _databaseContext.Products.FirstOrDefault(product => product.Id == newProduct.Id);
            if (oldProduct != null)
            {
                return;
            }
            oldProduct.Cost = newProduct.Cost;
            oldProduct.Description = newProduct.Description;
            oldProduct.Images = newProduct.Images;
            oldProduct.Length = newProduct.Length;
            oldProduct.CodeNumber = newProduct.CodeNumber;
            oldProduct.Square = newProduct.Square;
            oldProduct.Width = newProduct.Width;
            _databaseContext.SaveChanges();
        }
        public void AddNew(Product product)
        {
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _databaseContext.Products.ToList();
        }
    }
}
