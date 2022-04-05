using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }
        public void AddToCart(Product product)
        {
            Products.Add(product);
        }

        public List<Product> TryGetAll()
        {
            return Products ?? null;
        }

        public void RemoveFromCart(Product product)
        {
            Products.Remove(product);
        }
    }
}
