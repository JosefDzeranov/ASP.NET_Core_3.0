using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; }
        public Cart Cart { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime Date { get; set; }
        // public DateTime time { get; }


        public string UserId { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Не указан e-mail")]
        public string Email { get; set; }

        public Order(Cart cart)
        {
            Id = new Guid();
            Cart = cart;
            Status = OrderStatus.Created;
            Date = DateTime.Now;


        }

        public Order()
        {

        }

    }

}

