using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class BasketStorage
    {
        private List<Basket> productBaskets = new List<Basket>();

        public IEnumerable<Basket> ProductBaskets
        {
            get
            {
                return productBaskets;
            }
        }

        public void AddProductBasket(Product product)
        {
            var productBasket = productBaskets.Where(basket => basket.Product.Id == product.Id)
                                              .FirstOrDefault();
            if (productBasket == null)
            {
                productBaskets.Add(new Basket(product));
            }
            else
            {
                productBasket.Quantity++;
            }
        }

        public decimal GetTotalSum()
        {
            return productBaskets.Sum(basket => basket.Product.Cost * basket.Quantity);
        }
    }
}
