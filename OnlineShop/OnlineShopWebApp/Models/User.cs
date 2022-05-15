using OnlineShopWebApp.Models.Attributes;

namespace OnlineShopWebApp.Models
{
    [NewRegistrName]
    public class User
    {
        public User(int id, string name, string phone, string password)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Password = password;
        }

        public User(Registration registration)
        {
            Name = registration.Name;
            Password = registration.Password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }


    }
}
