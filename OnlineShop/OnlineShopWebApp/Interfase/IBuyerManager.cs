using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models.Users;
using OnlineShopWebApp.Models.Users.Buyer;
using Order = OnlineShop.Db.Models.Order;
using UserDeleveryInfo = OnlineShop.Db.Models.UserDeleveryInfo;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerManager
    {
        void AddBuyer(User user);
        void AddProductInCart(Product product, string buyerLogin);
        void DeleteProductInCart(Guid productId, string buyerLogin);
        void ReduceDuplicateProductCart(Guid productId, string buyerLogin);
        void Buy(string buyerLogin);
        void ClearCart(string buyerLogin);
        UserBuyer FindBuyer(string buyerLogin);
        void SaveInfoBuying(UserDeleveryInfo userDeleveryInfo, string buyerLogin);
        void ClearInfoBuying(string buyerLogin);
        void Remove(string login);
    }
}
