using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime OrderDate { get; set; }
        public Cart Cart { get; set; }
               
        public string UserId { get; set; }

        public OrderData OrderData { get; set; }
        //public string Name { get; set; }

        //public string Adress { get; set; }

        //public string Email { get; set; }

        public Order(Cart cart, OrderData orderData, string userId)
        {
            Cart = cart;
            OrderData = orderData;
            UserId = userId;
            OrderDate = DateTime.Now;

            Id = new Guid();
            Status = OrderStatus.Created;


        }
    }

}

