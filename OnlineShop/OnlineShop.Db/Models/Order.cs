using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Order  //Order
    {
        public Guid Id { get; set; }
        public UserDeleveryInfo UserDeleveryInfo { get; set; } //контактные данные
        public List<CartItem> Items { get; set; } // позиции заказа
        public OrderStatus Status { get; set; }
        public DateTime CreateDateTime { get; set; } 
        public string Login { get; set; }

        public Order()
        {
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.UtcNow;
        }
    }
}
