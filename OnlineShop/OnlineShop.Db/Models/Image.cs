using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Db.Models
{
    public class Image
    {
        public Guid ImageId { get; set; }
        public string Url { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
