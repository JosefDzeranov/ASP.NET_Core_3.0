namespace OnlineShopWebApp.Models
{
    public interface ICartsStorage
    {
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void DecreaseAmount(int productId, string userId);
        void Clear(string userId);
    }
}
