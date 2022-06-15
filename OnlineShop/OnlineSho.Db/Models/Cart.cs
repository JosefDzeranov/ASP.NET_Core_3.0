using System;
using System.Collections.Generic;


namespace OnlineShop.Db.Models
{
    public class Cart
    {
        public Guid Id {get; set;}

        public List<CartLine> CartLines {get; set;}
       
        public string UserId { get; set; } 

        public DateTime CreatedDateTime { get; set; }

        public Cart()
        {
            CreatedDateTime = DateTime.Now;
            CartLines = new List<CartLine>();
           
        }


    }
}

