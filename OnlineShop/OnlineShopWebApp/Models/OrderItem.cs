using OnlineShop.Db.Models;
using System;

namespace OnlineShopWebApp.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
        public decimal Cost
        {
            get;
        }
    }
}