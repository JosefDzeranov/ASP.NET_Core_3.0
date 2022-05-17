using OnlineShopWebApp.Models;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp
{
    public interface ICompareStorage
    {
        Compare TryGetByUserId(string userId);
        void AddProduct(string userId, Product product);
        void RemoveProduct(string userId, Product product);
        void Clear(string userId);
    }
}
