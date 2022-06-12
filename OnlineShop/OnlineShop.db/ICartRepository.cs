using OnlineShop.db.Models;


namespace OnlineShop.db

{
    public interface ICartRepository
    {
        void Add(int id, string userId);

        void Remove(int id, string userId);

        void Add(Product product, string userId);

        void Remove(Product product, string userId);

        void RemoveAll(string userId);

        Cart TryGetByUserId(string userId);

        void GetAllProduct();
    }
}