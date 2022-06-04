using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IComparison
    {
        public string UserId { get; set; }
        public List<Product> GetProducts(string userId);
        public void AddProduct(string userId, Product product);
    
        public Comparison TryGetComparisonByUserId(string userId);
        public void RemoveProduct(string userId, Guid id);


    }
}