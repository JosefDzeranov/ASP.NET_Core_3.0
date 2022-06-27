using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserInfo
    {
        public string Login { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "В фамилии должно быть не менее 2 букв")]
        public string Surname { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "В имени должно быть не менее 2 букв")]
        public string Firstname { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "В отчестве должно быть не менее 2 букв")]
        public string Secondname { get; set; }

        [Range(16, 110, ErrorMessage = "Возраст должен быть от 16 до 110")]
        public int Age { get; set; }

        [StringLength(12, MinimumLength = 11, ErrorMessage = "В телефоне должно быть от 11 знаков")]
        public string Phone { get; set; }

        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неверно заполнен email")]
        public string Email { get; set; }
    }
}
