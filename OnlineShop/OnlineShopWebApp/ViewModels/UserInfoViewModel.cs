using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels
{
    public class UserInfoViewModel
    {
        [Required(ErrorMessage = "не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "не указан email")]
        [EmailAddress(ErrorMessage = "некорректный формат email")]
        public string Email { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Phone { get; set; }
    }
}
