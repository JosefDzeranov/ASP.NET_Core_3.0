﻿using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerStorage
    {
        void AddProductInCart(int productId, int buyerId);
        void DeleteProductInCart(int productId, int buyerId);
        void ReduceDuplicateProductCart(int productId, int buyerId);
        void ReportTransaction(int buyerId);
        void ClearCart(int buyerId);
        Buyer FindBuyer(int buyerId);
    }
}
