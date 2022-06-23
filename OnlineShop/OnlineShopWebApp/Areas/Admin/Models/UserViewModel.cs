using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Фамилия должна содержать от 2-х до 25-ти символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2-х до 25-ти символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        public string Phone { get; set; }

        public IList<string> UserRoles { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public UserViewModel()
        {
            UserRoles = new List<string>();
        }
    }
}