using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Длинна логина должна от 4-х до 30-ти символов.")]
        public string Login { get; set; }
        public string FirstName { get; set; } = "Please, fill this field";
        public string LastName { get; set; } = "Please, fill this field";
        public string Phone { get; set; } = "Please, fill this field";
        public string Password { get; set; }

        public UserViewModel() { }


    }
}
