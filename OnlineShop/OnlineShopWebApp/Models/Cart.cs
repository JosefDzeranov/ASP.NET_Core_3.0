using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public List<Product> AddedProducts = new List<Product>();
        public int Id { get; }
        public static int IdCounter = 0;
        public string UserId = "UserId";

        public decimal CartCost
        {
            get
            {

                decimal Cost = 0;

                Cost = AddedProducts.Sum(x => x.TotalCost);
                return Cost;
            }
        }



        public Cart()
        {
            IdCounter++;
            Id = IdCounter;
        }

    }
}
