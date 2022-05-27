﻿using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models.Users;
using OnlineShopWebApp.Models.Users.Buyer;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerManager
    {
        void AddBuyer(User user);
        void AddProductInCart(Guid productId, string buyerLogin);
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
        void Remove(string login);
    }
}
