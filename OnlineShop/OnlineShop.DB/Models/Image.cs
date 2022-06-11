using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DB.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
