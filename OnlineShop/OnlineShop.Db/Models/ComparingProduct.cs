using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Db.Models
{
    class ComparingProduct
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
    }
}
