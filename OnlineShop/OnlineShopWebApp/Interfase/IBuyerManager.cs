using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models.Users;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerManager
    {
        void AddBuyer(User user);
        void AddProductInCart(Product product, string buyerLogin);
        void DeleteProductInCart(Guid productId, string buyerLogin);
        void ReduceDuplicateProductCart(Guid productId, string buyerLogin);
        List<Order> CollectAllOrders();
        Order FindOrderItem(Guid orderId);
        void UpdateOrderStatus(Order newOrder);
        void Buy(string buyerLogin);
        void ClearCart(string buyerLogin);
        UserBuyer FindBuyer(string buyerLogin);
        void SaveInfoBuying(UserDeleveryInfo userDeleveryInfo, string buyerLogin);
        void ClearInfoBuying(string buyerLogin);
        void Remove(string login);
    }
}
