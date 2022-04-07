using System;

namespace OnlineShopWebApp.Models
{
    public class Basket
    {
        public Guid Id;
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Basket (Product product, int quantity)
        {
            Id = new Guid();
            Product = product;
            Quantity = quantity;
        }
    }
}
