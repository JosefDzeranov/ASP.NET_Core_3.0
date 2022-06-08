using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserAccount
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Введите коректные данные")]
        public string Name { get; set; }
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Введите коректные данные")]
        [Required(ErrorMessage = "Не указана фамилия")]
        public string InputLastName { get; set; }
        [Required(ErrorMessage = "Не указана почта")]
        [EmailAddress(ErrorMessage = "Введите коректный адрес электронной почты")]
        public string InputEmail1 { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string InputPassword { get; set; }
        [Required(ErrorMessage = "Укажите повторно пароль")]
        [Compare("InputPassword", ErrorMessage = "Пароли не совпадают")]
        public bool InputConfirmPassword { get; set; }
    }
}
