using System.Linq;
using System.Collections.Generic;
using System;

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

        public Dictionary<Product, int> CartItems { get; set; }

        public Order()
        {
            idSequence = idSequence + 1;
            Id = idSequence;
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
            CartItems = new Dictionary<Product, int>();
        }

    
        public decimal Cost
        {
            get
            {
                return CartItems.Sum(item => item.Key.Cost * item.Value);
            }
        }
     
    }
}
