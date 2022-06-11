using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Db.Models
{
    public enum OrderStatus
    {
        Created,
        Processed,
        Delivering,
        Delivered,
        Canceled
    }
}
