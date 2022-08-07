using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class CartEntity
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemEntity> Items { get; set; }
        public bool IsDeleted { get; set; }
    }
}
