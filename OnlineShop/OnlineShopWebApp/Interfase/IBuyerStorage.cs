using OnlineDesignBureauWebApp.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerStorage
    {
        void AddProductInCart(Product product, int buyerId);
        void DeleteProductInCart(int productId, int personId);
        void ReduceDuplicateProductCart(int productId, int buyerId);
        void CleenCart(int buyerId);
        Buyer FindBuyer(int personId);
        void ReportTransaction(int buyerId);
    }
}
