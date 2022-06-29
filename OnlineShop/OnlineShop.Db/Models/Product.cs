using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public List<Image> Images { get; set; }

        public List<ProductResource> Names { get; set; }

        public decimal Cost { get; set; }

        public List<ProductResource> Descriptions { get; set; }

        public List<BasketItem> BasketItems { get; set; }

        public bool Available { get; set; }

        public  Product ()
        {
            BasketItems = new List<BasketItem>();
            Images = new List<Image>();
            Names = new List<ProductResource>();
            Descriptions = new List<ProductResource>();
        }

        public Product(Guid id, List<ProductResource> names, decimal cost, List<ProductResource> descriptions)
        {
            Id = id;
            Names = names;
            Cost = cost;
            Descriptions = descriptions;
            Available = true;
        }
    }
}
