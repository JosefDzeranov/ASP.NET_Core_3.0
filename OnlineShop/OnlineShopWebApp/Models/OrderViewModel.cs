using OnlineShop.DB.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{

    public class OrderViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        public CartViewModel Cart { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public OrderStatus Status { get; set; } = OrderStatus.New;
        [Required(ErrorMessage = "Имя не заполнено")]
        [StringLength(16, MinimumLength = 2, ErrorMessage = "имя должно быть от 2 до 16 символов")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилия не заполнена")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "имя должно быть от 2 до 25 символов")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "не указан email")]
        [EmailAddress(ErrorMessage = "некорректный формат email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "не указан телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "не указан адрес")]
        public string Address { get; set; }
        public decimal TotalCost { get; set; }
     

    }
}