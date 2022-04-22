using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerStorage
    {
        List<Buyer> Buyers { get; set; }
        void WriteToStorage();
        void ReadToStorage();
        void AddProductInCart(int productId, int buyerId, IProductStorage productStorage);
        void DeleteProductInCart(int productId, int personId);
        void ReduceDuplicateProductCart(int productId, int buyerId);
        void CleenCart(int buyerId);
        Buyer FindBuyer(int buyerId);
    }
}
