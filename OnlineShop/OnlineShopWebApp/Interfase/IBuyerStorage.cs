using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerStorage
    {
        List<Buyer> Buyers { get; set; }
        void WriteToStorage();
        void ReadToStorage();
        void AddProductInCart(int productId, int buyerId);
        void DeleteProductInCart(int productId, int buyerId);
        void ReduceDuplicateProductCart(int productId, int buyerId);
        void ClearCart(int buyerId);
        Buyer FindBuyer(int buyerId);
    }
}
