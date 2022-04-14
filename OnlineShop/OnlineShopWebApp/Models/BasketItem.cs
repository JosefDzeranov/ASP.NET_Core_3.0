using System;

namespace OnlineShopWebApp.Models
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Cost
        {
            get { return Product.Cost * Quantity; }
        }

        public BasketItem (Product product)
        {
            Id = Guid.NewGuid();
            Product = product;
            Quantity++;
        }
    }
}
