using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class BasketStorage
    {
        private List<Basket> baskets = new List<Basket>();

        public IEnumerable<Basket> Baskets
        {
            get
            {
                return baskets;
            }
        }

        public void AddProduct(Product product)
        {
            var basket = baskets.Where(basket => basket.Product.Id == product.Id)
                                              .FirstOrDefault();
            if (basket == null)
            {
                baskets.Add(new Basket(product));
            }
            else
            {
                basket.Quantity++;
            }
        }

        public decimal GetTotalSum()
        {
            return baskets.Sum(basket => basket.Product.Cost * basket.Quantity);
        }
    }
}
