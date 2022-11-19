using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.db.Models
{
    public class OrderStatusUpdatedEventArgs
    {
        public User User { get; set; }
        public OrderStatus OldStatus { get; set; }
        public OrderStatus NewStatus { get; set; }
        public Order Order { get; set; }
    }
}
