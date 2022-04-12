using System;

namespace OnlineShopWebApp.Models
{
    public class Basket
    {
        public Guid Id { get; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Basket (Product product)
        {
            Id = Guid.NewGuid();
            Product = product;
            Quantity++;
        }
    }
}
