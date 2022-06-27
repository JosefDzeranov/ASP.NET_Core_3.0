using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDeleveryInfo_ViewModels
    {
        public Guid Id { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "В фамилии должно быть не менее 2 букв")]
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "В имени должно быть не менее 2 букв")]
        [Required(ErrorMessage = "Не указано имя")]
        public string Firstname { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "В отчестве должно быть не менее 2 букв")]
        [Required(ErrorMessage = "Не указано отчество")]
        public string Secondname { get; set; }

        [StringLength(12, MinimumLength = 11, ErrorMessage = "В телефоне должно быть от 11 знаков")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неверно заполнен email")]
        public string Email { get; set; }

        public string Commentary { get; set; }
    }
}
