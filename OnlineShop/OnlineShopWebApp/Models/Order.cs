using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Cart Cart { get; set; }
               
        public string UserId { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Не указан e-mail")]
        public string Email { get; set; }

        public Order(Cart cart)
        {
            Cart = cart;
        }

        public Order()
        {

        }
     
    }

}

