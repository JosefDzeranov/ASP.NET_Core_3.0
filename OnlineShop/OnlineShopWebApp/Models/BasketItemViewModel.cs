using System;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class BasketItemViewModel
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Cost
        {
            get { return Product.Cost * Quantity; }
        }

        public BasketItemViewModel () { } // Empty ctor for XML serializing.
        public BasketItemViewModel (Product product)
        {
            Id = Guid.NewGuid();
            Product = product;
            Quantity++;
        }
        public BasketItemViewModel(Guid id, Product product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
