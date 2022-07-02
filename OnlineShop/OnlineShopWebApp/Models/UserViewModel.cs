using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Укажите Ваше имя")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 20 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Укажите Вашу фамилию")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Фамилия должна быть от 2 до 20 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "Укажите Ваш email")]
        [EmailAddress(ErrorMessage = "Укажите корректный email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AvatarPath { get; set; }
        public IFormFile UploadedImage { get; set; }
        
        public string TelegramUserId { get; set; }

        public string Address { get; set; }

        public string UserName { get; set; }

    }
}
