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
            BasketContent content = productCollection.Where(p => p.Product.Id == product.Id)
                                                     .FirstOrDefault();
            if(content == null)
            {
                productCollection.Add(new BasketContent
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else 
            {
                content.Quantity += quantity;
            }
        }

        public decimal GetTotalSum()
        {
            return productCollection.Sum(p => p.Product.Cost * p.Quantity);
        }
    }
}
