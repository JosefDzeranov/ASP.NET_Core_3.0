using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerStorage
    {
        void AddProductInCart(Product product, int buyerId);
        void DeleteProductInCart(int productId, int buyerId);
        void ReduceDuplicateProductCart(int productId, int buyerId);
        List<OrderItem> CollectAllOrders();
        OrderItem FindOrderItem(Guid orderId);
        void UpdateOrderDetails(OrderItem newOrder);
        void Buy(int buyerId);
        void ClearCart(int buyerId);
        Buyer FindBuyer(int buyerId);
        void SaveInfoBuying(InfoBuying infoBuying, int buyerId);
        void ClearInfoBuying(int buyerId);
    }
}
