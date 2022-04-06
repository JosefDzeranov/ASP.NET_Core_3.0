using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Basket
    {
        private static List<BasketContent> productCollection = new List<BasketContent>();

        public IEnumerable<BasketContent> ProductCollection
        {
            get
            {
                return productCollection;
            }
        }

        public void AddToBasket(Product product, int quantity)
        {
            BasketContent productInBasket = productCollection.Where(p => p.Product.Id == product.Id)
                                                     .FirstOrDefault();
            if(productInBasket == null)
            {
                productCollection.Add(new BasketContent
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else 
            {
                productInBasket.Quantity += quantity;
            }
        }

        public decimal GetTotalSum()
        {
            return productCollection.Sum(p => p.Product.Cost * p.Quantity);
        }
    }
}
