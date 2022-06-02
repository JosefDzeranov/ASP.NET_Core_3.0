using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указал электронный адрес")]
        [EmailAddress(ErrorMessage = "Не верный электронный адрес")]
        public string InputEmail1 { get; set; }
        [Required(ErrorMessage = "Неверно указан пароль")]
        [StringLength(100, MinimumLength = 4)]
        public string InputPassword { get; set; }
        public bool ExampleCheck1 { get; set; }
    }
}
