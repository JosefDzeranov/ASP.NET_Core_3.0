using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductsDbStorage : IProductsStorage
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public List<Product> GetAllAvailable()
        {
            return databaseContext.Products.Where(p => p.Available == true).ToList();
        }

        public Product TryGetProduct(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void SaveEditedProduct(Product newProduct)
        {
            var existingProduct = databaseContext.Products.FirstOrDefault(x => x.Id == newProduct.Id);

            if (existingProduct == null)
            {
                return;
            }

            existingProduct.ImagePath = newProduct.ImagePath;
            existingProduct.Name = newProduct.Name;
            existingProduct.Cost = newProduct.Cost;
            existingProduct.Description = newProduct.Description;
            existingProduct.Available = newProduct.Available;

            databaseContext.SaveChanges();
        }

        public void Delete(Guid productId)
        {
            var product = databaseContext.Products.FirstOrDefault(p => p.Id == productId);

            var orderWithProduct = databaseContext.Orders.Include(order => order.Items)
                                                 .ThenInclude(item => item.Product)
                                                 .FirstOrDefault(p => p.Id == product.Id);

            var cartItemWithProduct = databaseContext.CartItems.FirstOrDefault(x => x.Id == product.Id);

            if (orderWithProduct != null || cartItemWithProduct != null)
            {
                product.Available = false;
            }
            else
            {
                databaseContext.Products.Remove(product);
            }
            databaseContext.SaveChanges();
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            var products = databaseContext.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()));

            return products;
        }
    }
}
