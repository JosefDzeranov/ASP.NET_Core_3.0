using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerStorage
    {
        void AddProductInCart(Product product, Guid buyerId);
        void DeleteProductInCart(Guid productId, Guid buyerId);
        void ReduceDuplicateProductCart(Guid productId, Guid buyerId);
        List<OrderItem> CollectAllOrders();
        OrderItem FindOrderItem(Guid orderId);
        void UpdateOrderStatus(OrderItem newOrder);
        void Buy(Guid buyerId);
        void ClearCart(Guid buyerId);
        Buyer FindBuyer(Guid buyerId);
        void SaveInfoBuying(InfoBuying infoBuying, Guid buyerId);
        void ClearInfoBuying(Guid buyerId);
    }
}
