using System;

namespace OnlineShopWebApp.Models
{
    public class CartLineViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }

        public int Amount { get; set; }


        public decimal Cost
        {
            get
            {
                return Amount * Product.Cost;
            }
        }
        //public CartLineViewModel(ProductViewModel product)
        //{
        //    Product = product;
        //}

    }
}

