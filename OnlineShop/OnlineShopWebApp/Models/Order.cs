using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public string UserId { get; set; }

        public DateTime OrderDateTime { get; set; } = DateTime.Now;

        public Cart Cart { get; set; }

        //public List<CartItem> Items { get; set; }

        public decimal CostOrder { get; set; }

        //public int CountItems { get { return Items?.Sum(x => x.Count) ?? 0; } }

        //public decimal CostOrder { get { return Items?.Sum(x => x.Cost) ?? 0; } set { } }

        public OrderState State { get; set; } = OrderState.Created;

        [Required(ErrorMessage = "Имя не заполнено")]
        [StringLength(16, MinimumLength = 2, ErrorMessage = "имя должно быть от 2 до 16 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Фамилия не заполнена")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "имя должно быть от 2 до 25 символов")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "не указан email")]
        [EmailAddress(ErrorMessage = "некорректный формат email")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "не указан телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "не указан адрес")]
        public string Address { get; set; }
        //public decimal CostOrder { get; set; }
    }
}