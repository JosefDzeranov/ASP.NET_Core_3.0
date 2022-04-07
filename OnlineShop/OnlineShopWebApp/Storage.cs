using System;

namespace OnlineShopWebApp.Models
{
    public class Storage
    {
        public Guid Id;
        public Product Product { get; set; }
        public int Count { get; set; }

        public Storage(Product product, int count)
        {
            Id = new Guid();

            Product = product;

            Count = count;
        }
    }
}