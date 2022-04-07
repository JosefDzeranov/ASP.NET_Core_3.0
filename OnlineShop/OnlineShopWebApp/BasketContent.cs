using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class BasketContent
    {
        private static List<Basket> products = new List<Basket>();

        public IEnumerable<Basket> Products
        {
            get
            {
                return products;
            }
        }
        public void AddToBasket(Product product, int quantity)
        {
            Basket productInBasket = products.Where(p => p.Product.Id == product.Id)
                                                      .FirstOrDefault();
            if (productInBasket == null)
            {
                products.Add(new Basket(product, 1));
            }
            else
            {
                productInBasket.Quantity += quantity;
            }
        }
        public decimal GetTotalSum()
        {
            return products.Sum(p => p.Product.Cost * p.Quantity);
        }
    }
}
