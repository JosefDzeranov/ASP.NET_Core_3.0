using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }        
        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public Product TryGetById(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Edit(Product newProduct)
        {
            var product = databaseContext.Products.FirstOrDefault(x => x.Id == newProduct.Id);
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            product.Pages = newProduct.Pages;
            databaseContext.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var product = databaseContext.Products.FirstOrDefault(x => x.Id == id);
            databaseContext.Products.Remove(product);
        }

        public List<Product> TryGetByName(string name)
        {
            List<Product> findProducts = new List<Product>();
            {
                foreach (var product in databaseContext.Products)
                {
                    if (product.Name.ToLower().Contains(name.ToLower()))
                    {
                        findProducts.Add(product);
                    }
                }
            }
            return findProducts;
        }
    }
}

