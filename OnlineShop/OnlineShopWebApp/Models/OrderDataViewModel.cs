using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Db.Models
{
    public class OrderDataViewModel
    {
        public Guid Id { get; set; }
        public CartViewModel Cart { get; set; }
       
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Не указан e-mail")]
        public string Email { get; set; }

    
    }

}
