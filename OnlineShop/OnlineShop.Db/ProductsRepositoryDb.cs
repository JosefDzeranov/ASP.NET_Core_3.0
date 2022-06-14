using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ProductRepositoryDb : IProductsRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ProductRepositoryDb(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public List<Product> GetAll()
        {
            return dataBaseContext.Products.Include(x=>x.Images).ToList();
        }

        public Product TryGetById(Guid id)
        {
            return dataBaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Add(Product product)
        {
            product.ImagePath = "/images/item1.png";
            dataBaseContext.Products.Add(product);
            dataBaseContext.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = dataBaseContext.Products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Cost = product.Cost;
            existingProduct.Description = product.Description;
            dataBaseContext.SaveChanges();
        }
    }
}
