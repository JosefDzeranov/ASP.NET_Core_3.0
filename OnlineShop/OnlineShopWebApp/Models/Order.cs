using System.Linq;
using System.Collections.Generic;
using System;
using OnlineShop.db.Models;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        private static int idSequence = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime CreateDateTime { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Order()
        {
            idSequence = idSequence + 1;
            Id = idSequence;
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
            CartItems = new List<CartItem>();
        }

        public decimal Cost => CartItems.Sum(x => x.Cost);
    }
}
