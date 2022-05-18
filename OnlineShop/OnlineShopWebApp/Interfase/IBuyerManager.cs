using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerManager
    {
        void AddProductInCart(Product product, string buyerLogin);
        void DeleteProductInCart(Guid productId, string buyerLogin);
        void ReduceDuplicateProductCart(Guid productId, string buyerLogin);
        List<OrderItem> CollectAllOrders();
        OrderItem FindOrderItem(Guid orderId);
        void UpdateOrderStatus(OrderItem newOrder);
        void Buy(string buyerLogin);
        void ClearCart(string buyerLogin);
        UserBuyer FindBuyer(string buyerLogin);
        void SaveInfoBuying(InfoBuying infoBuying, string buyerLogin);
        void ClearInfoBuying(string buyerLogin);
    }
}
