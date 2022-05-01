using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Cart Cart { get; set; }
               
        public string UserId { get; set; }
        public string Name { get; set; }

        public string Adress { get; set; }

        public string Email { get; set; }

     
    }

}

