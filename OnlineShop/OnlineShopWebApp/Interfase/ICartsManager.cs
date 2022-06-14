using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface ICartsManager
    {
        List<Cart> GetAll();
        Cart Find(string buyerLogin);
        void CreateCartBuyer(string buyerLogin);
        void AddProductInCart(Guid productId, string buyerLogin);
        void UpCountInCartItem(Guid productId, string buyerLogin);
        void DownCountInCartItem(Guid productId, string buyerLogin);
        void DeleteProductInCart(Guid productId, string buyerLogin);
        void ReduceDuplicateProductCart(Guid productId, string buyerLogin);
        void ClearCart(string buyerLogin);
        int SumAllProducts(string buyerLogin);
        void SaveInfoBuying(UserDeleveryInfo userDeleveryInfo, string buyerLogin);
        void ClearInfoBuying(string buyerLogin);
    }
}