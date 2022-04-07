using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class CartStorage
    {
        private static List<Storage> products = new List<Storage>();

        public IEnumerable<Storage> Products
        {
            get
            {
                return products;
            }
        }

        public void AddToCart(Product product, int count)
        {
            Storage productCart = products.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            
            if (productCart == null)
            {
                //products.Add(productCart);
                products.Add (new Storage(product, 1));
            }
            else
            {
                productCart.Count += count;
            }
        }

        public decimal TryGetTotalSum()
        {
            return products.Sum(p => p.Product.Cost * p.Count);
        }
    }
}
