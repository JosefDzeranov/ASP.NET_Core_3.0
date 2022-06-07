using System;
using System.Collections.Generic;


namespace OnlineShop.Db.Models
{
    public class Cart
    {
        public Guid Id {get; set;}

        public List<CartLine> CartLines {get; set;}
       
        public string UserId { get; set; } 

        public Cart()
        {
            CartLines = new List<CartLine>();
           
        }


    }
}

