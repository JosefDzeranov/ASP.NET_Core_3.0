using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Customer
    {
        public Guid Id { get; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Фамилия должна содержать от 2-х до 25 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 2-х до 25 символов")]
        public string Name { get; set; }

        public List<Contacts> Contacts { get; set; }
    }
}