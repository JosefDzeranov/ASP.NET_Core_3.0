using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int OrderNumber { get; set; }

        public DateTime OrderDateTime { get; set; } = DateTime.Now;

        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public int CountItems { get { return Items?.Sum(x => x.Count) ?? 0; } }

        public decimal CostOrder { get { return Items?.Sum(x => x.Cost) ?? 0; } }

        public OrderState State { get; set; } = OrderState.Created;

        public Customer Customer { get; set; }
    }
}