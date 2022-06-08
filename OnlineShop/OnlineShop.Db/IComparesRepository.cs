using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IComparesRepository
    {
        List<Product> GetCompare(string userId);
        void Add(string userId, Product product);
        void Clear(string userId);
        void Delete(string userId, Guid productId);

    }
}