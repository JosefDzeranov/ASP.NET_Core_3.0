using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Fistname { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        public string Secondname { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указан возраст")]
        [Range(16, 110, ErrorMessage = "Возраст должен быть от 16 до 110")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8")]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage = "Проверочный пароль должен совпадать с паролем")]
        public string PasswordConfirm { get; set; }

    }
}
