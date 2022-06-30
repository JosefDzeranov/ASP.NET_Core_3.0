using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public List<Image> Images { get; set; }

        public List<ProductNameResource> Names { get; set; }

        public decimal Cost { get; set; }

        public List<ProductDescResource> Descriptions { get; set; }

        public List<BasketItem> BasketItems { get; set; }

        public bool Available { get; set; }

        public  Product ()
        {
            BasketItems = new List<BasketItem>();
            Images = new List<Image>();
            Names = new List<ProductNameResource>();
            Descriptions = new List<ProductDescResource>();
        }

        public Product(Guid id, List<ProductNameResource> names, decimal cost, List<ProductDescResource> descriptions)
        {
            Id = id;
            Names = names;
            Cost = cost;
            Descriptions = descriptions;
            Available = true;
        }
    }
}
