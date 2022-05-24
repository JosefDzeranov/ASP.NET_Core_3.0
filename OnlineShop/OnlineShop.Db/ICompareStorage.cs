using OnlineShop.Db.Models;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface ICompareStorage
    {
        List<Product> GetAllByUserId(string userId);
        void Add(string userId, Product product);
        void Remove(string userId, Product product);
        void Clear(string userId);
    }
}
