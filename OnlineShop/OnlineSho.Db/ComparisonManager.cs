using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ComparisonManager : IComparison
    {
        private readonly DataBaseContext dataBaseContext;
        public ComparisonManager(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public string UserId { get; set; }

      
        public List<Product> GetProducts(string userId)
        {
            var comparison = TryGetComparisonByUserId(userId);
            return comparison.Products;
        }

        public Comparison TryGetComparisonByUserId(string userId)
        {
            return dataBaseContext.Comparisons.Include(x => x.Products).FirstOrDefault(x => x.UserId == userId);
        }

        public void AddProduct(string userId, Product product)
        {
            var comparison = TryGetComparisonByUserId(userId);
            if (comparison == null)
            {
                comparison = new Comparison
                {
                    UserId = userId,

                };
                comparison.Products.Add(product);
                dataBaseContext.Comparisons.Add(comparison);

            }
            else
            {

                if (comparison.Products.FirstOrDefault(x => x.Id == product.Id) == null)
                {
                    comparison.Products.Add(product);
                }
            }


            dataBaseContext.SaveChanges();
        }

        public void RemoveProduct(string userId, Guid id)
        {

            var comparison = TryGetComparisonByUserId(userId);
            var productToRemove = comparison.Products.Find(x => x.Id == id);
            comparison.Products.Remove(productToRemove);
            dataBaseContext.SaveChanges();
        }

    }
}