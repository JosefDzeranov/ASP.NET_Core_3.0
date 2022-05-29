using System;

namespace OnlineShop.Db.Models
{
    public class CartLine
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }

        public Cart Cart { get; set; }

        public int Amount { get; set; }


     
    }
}

