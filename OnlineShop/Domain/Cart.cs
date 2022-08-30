using System;
using System.Collections.Generic;
using System.Linq;

namespace Domains
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public bool IsDeleted { get; set; }
    }
}
