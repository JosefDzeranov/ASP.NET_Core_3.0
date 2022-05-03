using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Cart Cart { get; set; }
               
        public string UserId { get; set; }

        [Required(ErrorMessage = "�� ������� ���")]
        public string Name { get; set; }

        [Required(ErrorMessage = "�� ������ �����")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "�� ������ e-mail")]
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

