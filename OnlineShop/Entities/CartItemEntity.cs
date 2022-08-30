using System;

namespace Entities
{
    public class CartItemEntity
    {
        public Guid Id { get; set; }
        public ProductEntity Product { get; set; }
        public CartEntity Cart { get; set; }
        public int Amount { get; set; }
    }
}
