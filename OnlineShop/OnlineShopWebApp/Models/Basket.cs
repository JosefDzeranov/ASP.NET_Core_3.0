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
            Id = new Guid();
            Product = product;
            Quantity++;
        }
    }
}
