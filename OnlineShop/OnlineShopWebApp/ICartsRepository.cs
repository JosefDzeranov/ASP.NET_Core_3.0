using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
        public interface ICartsRepository
        {
            Cart TryGetByUserId(string userId);
            void Add(ProductViewModel product, string userId);
            void Remove(ProductViewModel product, string userId);
            void Clear(string userId);
    }
    
}
