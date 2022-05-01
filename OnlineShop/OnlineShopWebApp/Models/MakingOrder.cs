using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class MakingOrder
    {
        public Cart Cart { get; set; }

        [Required(ErrorMessage ="Не указано имя") ]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Не указан e-mail")]
        public string Email { get; set; }

        public MakingOrder(Cart cart)
        {
            Cart = cart;
        }

    }

}
