using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IBasketStorage
    {
        List<Basket> Baskets { get; }
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        public void ClearBasket();
        decimal GetTotalSum();
    }
}
