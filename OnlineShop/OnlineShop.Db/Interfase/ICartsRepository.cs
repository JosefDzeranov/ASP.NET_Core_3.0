using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfase
{
    public interface ICartsRepository
    {
        List<Cart> GetAll();
        Cart Find(string buyerLogin);
        //UserDeleveryInfo FindUserDeleveryInfo(Guid id);
        void CreateCartBuyer(string buyerLogin);
        void AddProduct(Guid productId, string buyerLogin);
        void UpCountInCartItem(Guid productId, string buyerLogin);
        void DownCountInCartItem(Guid productId, string buyerLogin);
        void DeleteProductInCart(Guid productId, string buyerLogin);
        void ReduceDuplicateProductCart(Guid productId, string buyerLogin);
        void ClearCart(string buyerLogin);
        int QuantityAllProducts(string buyerLogin);
        void SaveInfoBuying(UserDeleveryInfo userDeleveryInfo, string buyerLogin);
        void ClearInfoBuying(string buyerLogin);
    }
}