using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductManager : IProductManager
    {
        private readonly DatabaseContext databaseContext;
        public ProductManager(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Product Find(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Delete(Product product)
        {
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }
        public void UpdateProduct(Product newProduct)
        {
            var oldProduct = databaseContext.Products.FirstOrDefault(product => product.Id == newProduct.Id);
            if (oldProduct != null)
            {
                return;
            }
            oldProduct.Cost = newProduct.Cost;
            oldProduct.Description = newProduct.Description;
            oldProduct.Images[0] = newProduct.Images[0];
            oldProduct.Length = newProduct.Length;
            oldProduct.CodeNumber = newProduct.CodeNumber;
            oldProduct.Square = newProduct.Square;
            oldProduct.Width = newProduct.Width;
            databaseContext.SaveChanges();
        }
        public void AddNew(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }
    }
}
