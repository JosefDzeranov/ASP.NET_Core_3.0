using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

namespace OnlineShopWebApp.Models
{
    public class InfoBuying
    {
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
        //[RegularExpression(@"^(+$)+@[0-9]{11}$", ErrorMessage = "Неверно заполнен номер")]
        //[RegularExpression(@"^([\+\s])*[O-9]{11}$", ErrorMessage = "Некорректный номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неверно заполнен email")]
        public string Email { get; set; }

        public string Commentary { get; set; }
    }
}
