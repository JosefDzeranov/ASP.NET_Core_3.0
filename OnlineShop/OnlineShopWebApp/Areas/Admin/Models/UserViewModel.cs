using System;
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

        public string Role { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public UserViewModel() { } // Empty ctor for XML serializing.

        public UserViewModel(Guid id, string firstname, string lastname, string role, string phone, string email, string password)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Phone = phone;
            Role = role;
            Email = email;
            Password = password;
        }
    }
}