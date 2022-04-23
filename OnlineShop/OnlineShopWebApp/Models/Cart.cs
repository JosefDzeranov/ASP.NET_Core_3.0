using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {

        public List<CartLine> CartLines = new List<CartLine>();
        public int Id { get; }
        public static int IdCounter = 0;
        public string UserId { get; set; }

        public decimal CartCost
        {
            get
            {
                decimal Cost = 0;

                Cost = CartLines.Sum(x => x.Cost);
                return Cost;
            }
        }


        public Cart(string userId)
        {
            IdCounter++;
            Id = IdCounter;
            UserId = userId;
        }
    }
}

