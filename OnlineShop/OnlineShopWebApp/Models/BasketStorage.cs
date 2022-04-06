using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class BasketStorage
    {
        private static List<Product> basket = new List<Product>();
        public static List<Product> AddToBasket(int id)
        {
            basket.Add(ProductsStorage.TryGetProduct(id));
            return basket;
        }
    }
}
