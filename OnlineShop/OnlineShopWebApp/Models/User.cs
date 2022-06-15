using System;
using System.ComponentModel.DataAnnotations;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        private IRoleManager roleManager { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Login { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Firstname { get; set; }

        public string Secondname { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        [Range(16, 110, ErrorMessage = "Возраст должен быть от 16 до 110")]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8")]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public string RoleName { get; set; }

        public Guid RoleId { get; set; }



    }
}
