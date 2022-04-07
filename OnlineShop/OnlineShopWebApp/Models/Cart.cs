using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public  class Cart
    {
        public  List<Product> addedProducts = new List<Product>();


        public  decimal CartCost
        {
            get
            {

                decimal cartCost = 0;

                foreach (var product in addedProducts)
                {
                    cartCost += product.TotalCost;
                }

                return cartCost;
            }
        }
             
        public int Id { get; }

        public Cart()
        {
            Id++;
        }

    }
}
