using System;

namespace OnlineShopWebApp.Models
{
    public class OrderItem
    {
        public CartItem CartItem { get; set; }
        public InfoBuying InfoBuying { get; set; }
        public DateTime dateTime { get; set; }

        public OrderItem()
        {
            dateTime = DateTime.UtcNow;
        }

    }
}
