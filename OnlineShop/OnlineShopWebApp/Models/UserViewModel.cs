using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Длинна логина должна от 4-х до 30-ти символов.")]
        public string Login { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }

        public UserViewModel() { }


    }
}
