using System.ComponentModel.DataAnnotations;

namespace OnlineShop.DB.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Длинна логина должна от 4-х до 30-ти символов.")]
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public User(string login, string phone, string password)
        {
            Login = login;
            Phone = phone;
            Password = password;
        }

        //public User(Registration registration)
        //{
        //    Login = registration.Login;
        //    Password = registration.Password;
        //}
        public User() { }


    }
}
