using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Db.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Cost
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
        }

        public decimal Amount
        {
            get
            {
                return Items.Sum(x => x.Count);
            }
        }

        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}