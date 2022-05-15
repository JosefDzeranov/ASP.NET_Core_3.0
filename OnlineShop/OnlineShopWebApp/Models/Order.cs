using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public int OrderNumber { get; set; }

        public DateTime OrderDateTime { get; set; }

        public string UserId { get; set; }

        public List<OrderItem> Items { get; set; }

        public int CountItems { get { return Items?.Sum(x => x.Count) ?? 0; } }

        public decimal CostOrder { get { return Items?.Sum(x => x.Cost) ?? 0; } }

        public OrderState State { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            State = OrderState.Created;
            OrderDateTime = DateTime.Now;
        }
    }
}